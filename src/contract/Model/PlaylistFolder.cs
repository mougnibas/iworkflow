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

namespace Mougnibas.MusicWorkflow.Contract.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;

    /// <summary>
    /// A music playlist folder.
    /// </summary>
    public sealed class PlaylistFolder
    {
        /// <summary>
        /// A list of playlists.
        /// </summary>
        private readonly List<Playlist> playlistsInternal;

        /// <summary>
        /// A readonly list of playlists (synchronized with the previous one).
        /// </summary>
        private ReadOnlyCollection<Playlist> playlistsRo;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistFolder"/> class.
        /// </summary>
        /// <param name="identifier">The playlist folder's identifier.</param>
        /// <param name="name">The playlist folder's name.</param>
        public PlaylistFolder(string identifier, string name)
        {
            this.Identifier = identifier;
            this.Name = name;
            this.playlistsInternal = new List<Playlist>();
            this.playlistsRo = new ReadOnlyCollection<Playlist>(this.playlistsInternal);
        }

        /// <summary>
        /// Gets the playlist folder's identifier.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        /// Gets the playlist folder's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the playlist folder's playlists.
        /// </summary>
        public ReadOnlyCollection<Playlist> Playlists
        {
            get
            {
                return this.playlistsRo;
            }
        }

        /// <summary>
        /// Add a playlist to the list.
        /// </summary>
        /// <param name="playlist">The playlist to add.</param>
        public void Add(Playlist playlist)
        {
            this.playlistsInternal.Add(playlist);
            this.playlistsRo = new ReadOnlyCollection<Playlist>(this.playlistsInternal);
        }

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
            return obj is PlaylistFolder playlistFolder &&
                   this.ToString().Equals(playlistFolder.ToString(), StringComparison.InvariantCulture);
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
            return string.Format(CultureInfo.InvariantCulture, "PlaylistFolder(Identifier='{0}', Name='{1}', Playlists='{2}')", this.Identifier, this.Name, string.Join<Playlist>(',', this.playlistsInternal));
        }
    }
}
