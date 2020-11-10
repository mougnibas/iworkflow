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

namespace Mougnibas.MusicWorkflow.Provider.Fake
{
    using System;
    using Mougnibas.MusicWorkflow.Contract.Model;
    using Mougnibas.MusicWorkflow.Contract.Service;

    /// <summary>
    /// Fake Music service provider.
    /// </summary>
    public class FakeMusicService : IMusicService
    {
        /// <summary>
        /// All tracks.
        /// </summary>
        private Track[] tracks;

        /// <summary>
        /// All playlist folders.
        /// </summary>
        private PlaylistFolder[] playlistFolders;

        /// <summary>
        /// Initialize the service.
        /// </summary>
        public void Init()
        {
            // Create fake tracks.
            Track[] tracks = new Track[]
            {
                new Track(80, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 1, "The Legend Of Zelda 25th Anniversary Medley", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/01%20The%20Legend%20Of%20Zelda%2025th%20Annivers.m4a"),
                new Track(82, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 2, "Kakariko Village (Twilight Princess Theme)", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/02%20Kakariko%20Village%20(Twilight%20Prince.m4a"),
                new Track(84, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 3, "The Wind Waker Symphonic Movement", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/03%20The%20Wind%20Waker%20Symphonic%20Movement.m4a"),
                new Track(86, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 4, "Gerudo Valley", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/04%20Gerudo%20Valley.m4a"),
                new Track(88, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 5, "Great Fairy's Fountain Theme", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/05%20Great%20Fairy's%20Fountain%20Theme.m4a"),
                new Track(90, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 6, "Twilight Princess Symphonic Movement", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/06%20Twilight%20Princess%20Symphonic%20Movem.m4a"),
                new Track(92, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 7, "The Legend Of Zelda Main Theme Medley", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/07%20The%20Legend%20Of%20Zelda%20Main%20Theme%20Me.m4a"),
                new Track(94, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 8, "Ballad Of The Goddess From Skyward Sword", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/08%20Ballad%20Of%20The%20Goddess%20From%20Skywar.m4a"),
            };

            // Create a fake playlist folder.
            PlaylistFolder playlistFolder = new PlaylistFolder("ADACB1B93A6C37C3", "Yoann");

            // Create a fake playlist and associate it to the previously created playlist folder.
            Playlist playlist = new Playlist(playlistFolder, "88A4FA1A260043F3", "My awesome TLOZ playlist", tracks);
            playlistFolder.Add(playlist);

            // Reference members
            this.tracks = tracks;
            this.playlistFolders = new PlaylistFolder[] { playlistFolder };
        }

        /// <summary>
        /// Get all the tracks.
        /// </summary>
        /// <returns>All the tracks.</returns>
        public Track[] GetTracks()
        {
            // Return the tracks.
            return this.tracks;
        }

        /// <summary>
        /// Get all The playlist folders.
        /// </summary>
        /// <returns>all The playlist folders.</returns>
        public PlaylistFolder[] GetPlaylistFolders()
        {
            // Return the playlist folders.
            return this.playlistFolders;
        }

        /// <summary>
        /// Get the playlist folder identified by its identifier.
        /// </summary>
        /// <param name="identifier">The playlist folder identifier.</param>
        /// <returns>The playlist folder searched, or null if not found.</returns>
        public PlaylistFolder GetPlaylistFolder(string identifier)
        {
            if (!"ADACB1B93A6C37C3".Equals(identifier, StringComparison.InvariantCulture))
            {
                return null;
            }

            return this.playlistFolders[0];
        }

        /// <summary>
        /// Get the playlist identified by its identifier.
        /// </summary>
        /// <param name="identifier">The playlist identifier.</param>
        /// <returns>The playlist searched, or null if not found.</returns>
        public Playlist GetPlaylist(string identifier)
        {
            if (!"88A4FA1A260043F3".Equals(identifier, StringComparison.InvariantCulture))
            {
                return null;
            }

            return this.playlistFolders[0].Playlists[0];
        }
    }
}
