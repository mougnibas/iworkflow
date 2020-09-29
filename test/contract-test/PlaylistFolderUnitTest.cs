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

namespace Mougnibas.MusicWorkflow.Contract.Model.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Playlist folder unit test class.
    /// </summary>
    [TestClass]
    public class PlaylistFolderUnitTest
    {
        /// <summary>
        /// Test the <see cref="PlaylistFolder.PlaylistFolder(string, string)"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithIdentifierAndNameReturnSameIdentifierReference()
        {
            // Arrange
            string identifier = "my identifier";
            PlaylistFolder playlistFolder = new PlaylistFolder(identifier, "my name");
            string expected = identifier;

            // Act
            string actual = playlistFolder.Identifier;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.PlaylistFolder(string, string)"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithIdentifierAndNameReturnSameNameReference()
        {
            // Arrange
            string name = "my name";
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", name);
            string expected = name;

            // Act
            string actual = playlistFolder.Name;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Identifier"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithIdentifierAndNameReturnSameIdentifier()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            string expected = "my identifier";

            // Act
            string actual = playlistFolder.Identifier;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Name"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithIdentifierAndNameReturnSameName()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            string expected = "my name";

            // Act
            string actual = playlistFolder.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Add(Playlist)"/> method.
        /// </summary>
        [TestMethod]
        public void AddPlaylistReturnSamePlaylist()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            playlistFolder.Add(new Playlist("identifier", "name", Array.Empty<Track>()));
            Playlist expected = new Playlist("identifier", "name", Array.Empty<Track>());

            // Act
            Playlist actual = playlistFolder.Playlists[0];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Add(Playlist)"/> method.
        /// </summary>
        [TestMethod]
        public void AddPlaylistReturnSamePlaylistReference()
        {
            // Arrange
            Playlist playlist = new Playlist("identifier", "name", Array.Empty<Track>());
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            playlistFolder.Add(playlist);
            Playlist expected = playlist;

            // Act
            Playlist actual = playlistFolder.Playlists[0];

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void SamePlaylistFoldersAreEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            PlaylistFolder samePlaylistFolder = new PlaylistFolder("my identifier", "my name");

            // Act and assert
            Assert.AreEqual(playlistFolder, samePlaylistFolder);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void SamePlaylistFoldersAreEqualInReverseOrder()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            PlaylistFolder samePlaylistFolder = new PlaylistFolder("my identifier", "my name");

            // Act and assert
            Assert.AreEqual(samePlaylistFolder, playlistFolder);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TwoPlaylistFolderNotEqualOnIdentifierAreNotEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            PlaylistFolder otherPlaylistFolder = new PlaylistFolder("my other identifier", "my name");

            // Act and assert
            Assert.AreNotEqual(playlistFolder, otherPlaylistFolder);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TwoPlaylistFolderNotEqualOnNameAreNotEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            PlaylistFolder otherPlaylistFolder = new PlaylistFolder("my identifier", "my other name");

            // Act and assert
            Assert.AreNotEqual(playlistFolder, otherPlaylistFolder);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void PlaylistFolderAndNullAreNotEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");

            // Act and assert
            Assert.AreNotEqual(playlistFolder, null);
        }

        /// <summary>
        /// Test the <see cref="PlaylistFolder.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void PlaylistFolderAndStringAreNotEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");

            // Act and assert
            Assert.AreNotEqual(playlistFolder, "PlaylistFolder(Identifier='my identifier', Name='my name')");
        }

        /// <summary>
        /// Test <see cref="PlaylistFolder.GetHashCode()"/> method.
        /// </summary>
        /// <remarks>
        ///     GetHashCode on two equals strings return the same hash code,
        ///     but this hashcode value may be different accross run,
        ///     dotnet implementations and dotnet versions.
        /// </remarks>
        [TestMethod]
        public void HashcodeOfSamePlaylistFoldersAreEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            PlaylistFolder otherPlaylistFolder = new PlaylistFolder("my identifier", "my name");
            int expected = playlistFolder.GetHashCode();

            // Act
            int actual = otherPlaylistFolder.GetHashCode();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="PlaylistFolder.GetHashCode()"/> method.
        /// </summary>
        /// <remarks>
        ///     GetHashCode on two equals strings return the same hash code,
        ///     but this hashcode value may be different accross run,
        ///     dotnet implementations and dotnet versions.
        /// </remarks>
        [TestMethod]
        public void HashcodeOfTwoPlaylistFolderNotEqualOnIdentifierAreNotEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            PlaylistFolder otherPlaylistFolder = new PlaylistFolder("my other identifier", "my name");
            int expected = playlistFolder.GetHashCode();

            // Act
            int actual = otherPlaylistFolder.GetHashCode();

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="PlaylistFolder.GetHashCode()"/> method.
        /// </summary>
        /// <remarks>
        ///     GetHashCode on two equals strings return the same hash code,
        ///     but this hashcode value may be different accross run,
        ///     dotnet implementations and dotnet versions.
        /// </remarks>
        [TestMethod]
        public void HashcodeOfTwoPlaylistFolderNotEqualOnNameAreNotEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            PlaylistFolder otherPlaylistFolder = new PlaylistFolder("my identifier", "my other name");
            int expected = playlistFolder.GetHashCode();

            // Act
            int actual = otherPlaylistFolder.GetHashCode();

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.ToString"/> constructor.
        /// </summary>
        [TestMethod]
        public void PlaylistFolderToStringAndForgedStringAreEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            string expected = "PlaylistFolder(Identifier='my identifier', Name='my name', Playlists='')";

            // Act
            string actual = playlistFolder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.ToString"/> constructor.
        /// </summary>
        [TestMethod]
        public void PlaylistFolderWithPlaylistsToStringAndForgedStringAreEqual()
        {
            // Arrange
            PlaylistFolder playlistFolder = new PlaylistFolder("my identifier", "my name");
            Playlist playlist = new Playlist(playlistFolder, "identifier", "name", Array.Empty<Track>());
            playlistFolder.Add(playlist);
            string expected = "PlaylistFolder(Identifier='my identifier', Name='my name', Playlists='Playlist(Parent='my identifier', Identifier='identifier', Name='name', Tracks='')')";

            // Act
            string actual = playlistFolder.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
