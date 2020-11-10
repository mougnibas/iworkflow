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

namespace Mougnibas.MusicWorkflow.Contract.Service
{
    using Mougnibas.MusicWorkflow.Contract.Model;

    /// <summary>
    /// A music playlist.
    /// </summary>
    public interface IMusicService
    {
        /// <summary>
        /// Initialize the service.
        /// </summary>
        void Init();

        /// <summary>
        /// Get all the tracks.
        /// </summary>
        /// <returns>All the tracks.</returns>
        Track[] GetTracks();

        /// <summary>
        /// Get all The playlist folders.
        /// </summary>
        /// <returns>all The playlist folders.</returns>
        PlaylistFolder[] GetPlaylistFolders();

        /// <summary>
        /// Get the playlist folder identified by its identifier.
        /// </summary>
        /// <param name="identifier">The playlist folder identifier.</param>
        /// <returns>The playlist folder searched, or null if not found.</returns>
        PlaylistFolder GetPlaylistFolder(string identifier);

        /// <summary>
        /// Get the playlist identified by its identifier.
        /// </summary>
        /// <param name="identifier">The playlist identifier.</param>
        /// <returns>The playlist searched, or null if not found.</returns>
        Playlist GetPlaylist(string identifier);
    }
}
