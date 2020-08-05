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
    using System.Collections.ObjectModel;
    using System.Globalization;

    /// <summary>
    /// A music playlist.
    /// </summary>
    public sealed class Playlist
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Playlist"/> class.
        /// </summary>
        /// <param name="identifier">The playlist's identifier.</param>
        /// <param name="name">The playlist's name.</param>
        /// <param name="tracks">The playlist's tracks.</param>
        public Playlist(string identifier, string name, Track[] tracks)
        {
            this.Parent = null;
            this.Identifier = identifier;
            this.Name = name;
            this.Tracks = new ReadOnlyCollection<Track>(tracks);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Playlist"/> class.
        /// </summary>
        /// <param name="parent">The (optional) playlist folder's parent.</param>
        /// <param name="identifier">The playlist's identifier.</param>
        /// <param name="name">The playlist's name.</param>
        /// <param name="tracks">The playlist's tracks.</param>
        public Playlist(PlaylistFolder parent, string identifier, string name, Track[] tracks)
        {
            this.Parent = parent;
            this.Identifier = identifier;
            this.Name = name;
            this.Tracks = new ReadOnlyCollection<Track>(tracks);
        }

        /// <summary>
        /// Gets the (optional) playlist folder's parent.
        /// </summary>
        public PlaylistFolder Parent { get; }

        /// <summary>
        /// Gets the playlist's identifier.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Gets the playlist's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the playlist's tracks.
        /// </summary>
        public ReadOnlyCollection<Track> Tracks { get; }

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
            return obj is Playlist playlist &&
                   this.ToString().Equals(playlist.ToString(), StringComparison.InvariantCulture);
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
            if (this.Parent == null)
            {
                return string.Format(CultureInfo.InvariantCulture, "Playlist(Parent='', Identifier='{0}', Name='{1}', Tracks='{2}')", this.Identifier, this.Name, string.Join<Track>(',', this.Tracks));
            }
            else
            {
                return string.Format(CultureInfo.InvariantCulture, "Playlist(Parent='{0}', Identifier='{1}', Name='{2}', Tracks='{3}')", this.Parent.Identifier, this.Identifier, this.Name, string.Join<Track>(',', this.Tracks));
            }
        }
    }
}
