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

namespace Mougnibas.MusicWorkflow.Database
{
    using System;
    using System.Globalization;

    /// <summary>
    /// A music track metadata.
    /// </summary>
    public sealed class Track
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Track"/> class.
        /// </summary>
        /// <param name="trackID">The track's identifier.</param>
        /// <param name="albumArtist">The track's Album's artist.</param>
        /// <param name="album">The track's Album's name.</param>
        /// <param name="trackNumber">The track's number.</param>
        /// <param name="name">The track's name.</param>
        /// <param name="artist">The track's artist.</param>
        /// <param name="location">The track's location.</param>
        public Track(int trackID, string albumArtist, string album, int trackNumber, string name, string artist, string location)
        {
            this.TrackID = trackID;
            this.AlbumArtist = albumArtist;
            this.Album = album;
            this.TrackNumber = trackNumber;
            this.Name = name;
            this.Artist = artist;
            this.Location = location;
        }

        /// <summary>
        /// Gets the track's identifier.
        /// </summary>
        public int TrackID { get; }

        /// <summary>
        /// Gets the track's Album's artist.
        /// </summary>
        public string AlbumArtist { get; }

        /// <summary>
        /// Gets the track's Album's name.
        /// </summary>
        public string Album { get; }

        /// <summary>
        /// Gets the track's number.
        /// </summary>
        public int TrackNumber { get; }

        /// <summary>
        /// Gets the track's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the track's artist.
        /// </summary>
        public string Artist { get; }

        /// <summary>
        /// Gets the track's location.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Check if the given object in parameter is equivalent to this one.
        /// </summary>
        /// <returns>
        ///     'true' if the given object in parameter is equivalent to this one,
        ///     'false' otherwise.
        /// </returns>
        /// <param name="obj">The object to compare from.</param>
        public override bool Equals(object obj)
        {
            return obj is Track track &&
                   this.ToString().Equals(track.ToString(), StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Return the hashcode of this object.
        /// </summary>
        /// <returns>the hashcode of this object.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode(StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Return a string representation of this object.
        /// </summary>
        /// <returns>A string representation of this object.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Track(TrackID='{0}', AlbumArtist='{1}', Album='{2}', TrackNumber='{3}', Name='{4}', Artist='{5}', Location='{6}')", this.TrackID, this.AlbumArtist, this.Album, this.TrackNumber, this.Name, this.Artist, this.Location);
        }
    }
}
