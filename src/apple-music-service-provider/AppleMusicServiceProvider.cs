// Copyright (c) 2020 Yoann MOUGNIBAS
//
// This file is part of MusicWorkflow.
//
// MusicWorkflow is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MusicWorkflow is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MusicWorkflow.  If not, see <https://www.gnu.org/licenses/>.

namespace Mougnibas.MusicWorkflow.Provider.AppleMusicService
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Xml;

    using Mougnibas.MusicWorkflow.Contract.Model;
    using Mougnibas.MusicWorkflow.Contract.Service;
    using Mougnibas.MusicWorkflow.Provider.AppleMusicService.Exceptions;

    /// <summary>
    /// An Apple iTunes Library XML Parser class.
    /// </summary>
    public class AppleMusicServiceProvider : IMusicService
    {
        /// <summary>
        /// The tracks of the iTunes Music Library XML file.
        /// </summary>
        private List<Track> tracks;

        /// <summary>
        /// The playlist folders.
        /// </summary>
        private List<PlaylistFolder> playlistFolders;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppleMusicServiceProvider"/> class.
        /// </summary>
        public AppleMusicServiceProvider()
        {
            // Set the default iTunes Music Library.xml file to use.
            // Example : "C:\\Users\\Yoann\\Music\\iTunes\\iTunes Music Library.xml"
            this.Path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic) + "\\iTunes\\iTunes Music Library.xml";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppleMusicServiceProvider"/> class.
        /// </summary>
        /// <param name="path">The path to the iTunes Music Library XML file.</param>
        public AppleMusicServiceProvider(string path)
        {
            // Use the given path as reference
            this.Path = path;
        }

        /// /// <summary>
        /// Gets the path to the iTunes Music Library XML file.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Load the XML content, then parse it.
        /// </summary>
        public void Init()
        {
            // Read the content.
            string xmlContent = this.ReadToEnd();

            // Handle tracks part
            this.tracks = new List<Track>();
            var trackDict = MakeTracksFromRawXml(xmlContent);
            this.tracks.AddRange(trackDict.Values);

            // Handle playlist part
            this.playlistFolders = new List<PlaylistFolder>();
            var playlistFoldersArray = MakePlaylistFoldersFromRawXml(trackDict, xmlContent);
            this.playlistFolders.AddRange(playlistFoldersArray);
        }

        /// <summary>
        /// Get all the tracks (must be loaded and parsed first).
        /// </summary>
        /// <returns>All the tracks.</returns>
        public Track[] GetTracks()
        {
            return this.tracks.ToArray();
        }

        /// <summary>
        /// Get all The playlist folders (must be loaded and parsed first).
        /// </summary>
        /// <returns>all The playlist folders.</returns>
        public PlaylistFolder[] GetPlaylistFolders()
        {
            return this.playlistFolders.ToArray();
        }

        /// <summary>
        /// Make tracks object from raw xml content.
        /// </summary>
        /// <param name="xmlContent">Raw xml content.</param>
        /// <returns>Tracks object from raw xml content.</returns>
        private static Dictionary<int, Track> MakeTracksFromRawXml(string xmlContent)
        {
            // The track list
            Dictionary<int, Track> trackDict = new Dictionary<int, Track>();

            // Get he content "after <key>Tracks</key>" and before "<key>Playlists</key>"
            string afterTracks = xmlContent.Split("<key>Tracks</key>")[1];
            string beforePlaylist = afterTracks.Split("<key>Playlists</key>")[0];
            string tracksXml = beforePlaylist;

            // Load the XML tracks string into a "real" xml object
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(tracksXml);
            foreach (XmlNode trackDictChilds in xmlDocument.ChildNodes[0].ChildNodes)
            {
                // Only parse "dict" child (ignore "<key>xxx</key>" lines)
                // Each "dict" entries is a track
                if (!trackDictChilds.Name.Equals("dict", StringComparison.InvariantCulture))
                {
                    continue;
                }

                // Create the track and add it to the list
                Track track = MakeTrackFromChilds(trackDictChilds);
                trackDict.Add(track.TrackID, track);
            }

            // Return the result
            return trackDict;
        }

        /// <summary>
        /// Make PlayListFolder objects from raw xml content.
        /// </summary>
        /// <param name="trackDict">A dictionary of tracks.</param>
        /// <param name="xmlContent">Raw xml content.</param>
        /// <returns>PlayListFolder objects from raw xml content.</returns>
        private static PlaylistFolder[] MakePlaylistFoldersFromRawXml(Dictionary<int, Track> trackDict, string xmlContent)
        {
            // The track list
            Dictionary<string, PlaylistFolder> playlistFolderDict = new Dictionary<string, PlaylistFolder>();

            // Get he content "after <key>Playlists</key>" and before "<key>Music Folder</key>"
            string afterPlaylists = xmlContent.Split("<key>Playlists</key>")[1];
            string beforeMusicFolder = afterPlaylists.Split("<key>Music Folder</key>")[0];
            string playlistsXml = beforeMusicFolder;

            // Load the XML playlists string into a "real" xml object
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(playlistsXml);
            foreach (XmlNode playlistDictChilds in xmlDocument.ChildNodes[0].ChildNodes)
            {
                // Populate PlaylistFolder list
                PopulatePlaylistFolder(trackDict, playlistFolderDict, playlistDictChilds);
            }

            // Return the result
            return new List<PlaylistFolder>(playlistFolderDict.Values).ToArray();
        }

        /// <summary>
        /// Make a track object from a xml node.
        /// </summary>
        /// <param name="node">The xml node.</param>
        /// <returns>A track.</returns>
        private static Track MakeTrackFromChilds(XmlNode node)
        {
            // The track informations to populate
            int trackID = -1;
            string albumArtist = null;
            string album = null;
            int trackNumber = -1;
            string name = null;
            string artist = null;
            string location = null;

            // List of key/value track informations
            foreach (XmlNode keyOrValueTrackInfo in node)
            {
                // Work only on "key" child, then get the next sibling ("value")
                if (!keyOrValueTrackInfo.Name.Equals("key", StringComparison.InvariantCulture))
                {
                    continue;
                }

                // Get the "key" and "value" of the current track information
                string key = keyOrValueTrackInfo.InnerText;
                string value = keyOrValueTrackInfo.NextSibling.InnerText;

                // Only few informations fit in this model.
                // Filter them.
                if (key.Equals("Track ID", StringComparison.InvariantCulture))
                {
                    trackID = int.Parse(value, CultureInfo.InvariantCulture);
                }
                else if (key.Equals("Composer", StringComparison.InvariantCulture))
                {
                    albumArtist = value;
                }
                else if (key.Equals("Album", StringComparison.InvariantCulture))
                {
                    album = value;
                }
                else if (key.Equals("Track Number", StringComparison.InvariantCulture))
                {
                    trackNumber = int.Parse(value, CultureInfo.InvariantCulture);
                }
                else if (key.Equals("Name", StringComparison.InvariantCulture))
                {
                    name = value;
                }
                else if (key.Equals("Artist", StringComparison.InvariantCulture))
                {
                    artist = value;
                }
                else if (key.Equals("Location", StringComparison.InvariantCulture))
                {
                    location = value;
                }
            }

            // Instantiate the track
            Track track = new Track(trackID, albumArtist, album, trackNumber, name, artist, location);

            // Return the result
            return track;
        }

        /// <summary>
        /// Poulate playlist folder from previously read playlist folder and xml node.
        /// </summary>
        /// <param name="trackDict">A dictionary of tracks.</param>
        /// <param name="playlistFolderDict">The playlist folder dictionary.</param>
        /// <param name="node">The xml node.</param>
        private static void PopulatePlaylistFolder(Dictionary<int, Track> trackDict, Dictionary<string, PlaylistFolder> playlistFolderDict, XmlNode node)
        {
            // The playlist folder informations to populate
            string parentPersistentID = string.Empty;
            string playlistPersistentID = string.Empty;
            string name = string.Empty;
            List<Track> currentTrackList = new List<Track>();

            // List of key/value playlist informations
            foreach (XmlNode subNode in node)
            {
                // Work only on "key" child, then get the next sibling ("value")
                if (subNode.Name.Equals("key", StringComparison.InvariantCulture))
                {
                    // Get the "key" and "value" of the current track information
                    string key = subNode.InnerText;
                    string value = subNode.NextSibling.InnerText;

                    // Only few informations fit in this model.
                    // Filter them.
                    if (key.Equals("Playlist Persistent ID", StringComparison.InvariantCulture))
                    {
                        playlistPersistentID = value;
                    }
                    else if (key.Equals("Name", StringComparison.InvariantCulture))
                    {
                        name = value;
                    }
                    else if (key.Equals("Parent Persistent ID", StringComparison.InvariantCulture))
                    {
                        parentPersistentID = value;
                    }
                }

                // Maybe it's an array (playlist tracks) ?
                else if (subNode.Name.Equals("array", StringComparison.InvariantCulture))
                {
                    // Create the current track list from this subnode and the dictionary of tracks
                    currentTrackList = MakeCurrentTrackList(trackDict, subNode);
                }
            }

            // Apply some filters here, because some playlist are defaut ones
            // Filter : "Library", "Downloaded", "Music", "Movies", "TV Shows", "Podcasts" and "Audiobooks"
            if (name.Equals("Library", StringComparison.InvariantCulture) ||
                name.Equals("Downloaded", StringComparison.InvariantCulture) ||
                name.Equals("Music", StringComparison.InvariantCulture) ||
                name.Equals("Movies", StringComparison.InvariantCulture) ||
                name.Equals("TV Shows", StringComparison.InvariantCulture) ||
                name.Equals("Podcasts", StringComparison.InvariantCulture) ||
                name.Equals("Audiobooks", StringComparison.InvariantCulture))
            {
                return;
            }

            // If it has not a parent, it's a playlist folder
            if (parentPersistentID.Length == 0)
            {
                // Instantiate the PlaylistFolder add it to the list
                PlaylistFolder playlistFolder = new PlaylistFolder(playlistPersistentID, name);
                playlistFolderDict.Add(playlistFolder.Identifier, playlistFolder);
            }

            // Else, it's a playlist from a playlist folder
            else
            {
                // Get the playlist folder
                PlaylistFolder parent = playlistFolderDict[parentPersistentID];

                // Create the playlist
                Playlist playlist = new Playlist(parent, playlistPersistentID, name, currentTrackList.ToArray());

                // Add the playlist to the folder
                parent.Add(playlist);
            }
        }

        /// <summary>
        /// Create a track list from a track dictionary and a playlist Xml node.
        /// </summary>
        /// <param name="trackDict">The track dictionary.</param>
        /// <param name="subNode">The playlist Xml node.</param>
        /// <returns>a track list.</returns>
        private static List<Track> MakeCurrentTrackList(Dictionary<int, Track> trackDict, XmlNode subNode)
        {
            // Initialise an empty list
            List<Track> trackList = new List<Track>();

            // For each subnode track identifier, get the corresponding track
            foreach (XmlNode subSubNode in subNode)
            {
                // Get the track object from the track identifier
                int trackIdentifier = int.Parse(subSubNode.FirstChild.NextSibling.InnerText, CultureInfo.InvariantCulture);
                Track track = trackDict[trackIdentifier];

                // Add the track to the list
                trackList.Add(track);
            }

            // Return the result
            return trackList;
        }

        /// <summary>
        /// Read the XML file and cache it into a string.
        /// </summary>
        /// <returns>A cached string from the XML content.</returns>
        private string ReadToEnd()
        {
            // Try to get a stream reader from the XML file path and try to read (keep in memory) all the XML content.
            string xmlContent;
            try
            {
                // Open the file, then read all it contents.
                using var reader = File.OpenText(this.Path);
                xmlContent = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                var message = string.Format(CultureInfo.InvariantCulture, "Can't read all the content of the file '{0}'", this.Path);
                throw new XmlFileReadException(message, ex);
            }

            // Return the result.
            return xmlContent;
        }
    }
}
