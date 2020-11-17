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

namespace Mougnibas.MusicWorkflow.Test.Contract.Model
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.MusicWorkflow.Contract.Model;

    /// <summary>
    /// Playlist unit test class.
    /// </summary>
    [TestClass]
    public class PlaylistUnitTest
    {
        /// <summary>
        /// Test the <see cref="Playlist.Playlist(PlaylistFolder, string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithParentReturnSameParentReference()
        {
            // Arrange
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, "another identifier", "another name", Array.Empty<Track>());
            PlaylistFolder expected = parent;

            // Act
            PlaylistFolder actual = playlist.Parent;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(PlaylistFolder, string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithParentReturnSameIdentifierReference()
        {
            // Arrange
            string identifier = "another identifier";
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, identifier, "another name", Array.Empty<Track>());
            string expected = identifier;

            // Act
            string actual = playlist.Identifier;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(PlaylistFolder, string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithParentReturnSameNameReference()
        {
            // Arrange
            string name = "another name";
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, "another identifier", name, Array.Empty<Track>());
            string expected = name;

            // Act
            string actual = playlist.Name;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(PlaylistFolder, string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithParentReturnSameTracks()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, "another identifier", "another name", tracks);
            ReadOnlyCollection<Track> expected = new ReadOnlyCollection<Track>(tracks);

            // Act
            ReadOnlyCollection<Track> actual = playlist.Tracks;

            // Assert
            CollectionAssert.Equals(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithoutParentReturnSameIdentifierReference()
        {
            // Arrange
            string identifier = "another identifier";
            Playlist playlist = new Playlist(identifier, "another name", Array.Empty<Track>());
            string expected = identifier;

            // Act
            string actual = playlist.Identifier;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithoutParentReturnSameNameReference()
        {
            // Arrange
            string name = "another name";
            Playlist playlist = new Playlist("another identifier", name, Array.Empty<Track>());
            string expected = name;

            // Act
            string actual = playlist.Name;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithoutParentReturnSameTracks()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("another identifier", "another name", tracks);
            ReadOnlyCollection<Track> expected = new ReadOnlyCollection<Track>(tracks);

            // Act
            ReadOnlyCollection<Track> actual = playlist.Tracks;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Parent"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithParentReturnSameParent()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, "another identifier", "another name", tracks);
            PlaylistFolder expected = parent;

            // Act
            PlaylistFolder actual = playlist.Parent;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Identifier"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithoutParentReturnSameIdentifier()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);
            string expected = "identifier";

            // Act
            string actual = playlist.Identifier;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Name"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithoutParentReturnSameName()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);
            string expected = "name";

            // Act
            string actual = playlist.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void SamePlaylistWithoutParentAreEqual()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("another identifier", "another name", tracks);
            Playlist anotherPlaylist = new Playlist("another identifier", "another name", tracks);

            // Act and assert
            Assert.AreEqual(playlist, anotherPlaylist);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void SamePlaylistWithoutParentAreEqualInReverseOrder()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("another identifier", "another name", tracks);
            Playlist anotherPlaylist = new Playlist("another identifier", "another name", tracks);

            // Act and assert
            Assert.AreEqual(anotherPlaylist, playlist);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void SamePlaylistWithParentAreEqual()
        {
            // Arrange
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            PlaylistFolder anotherParent = new PlaylistFolder("identifier", "name");
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist(parent, "another identifier", "another name", tracks);
            Playlist anotherPlaylist = new Playlist(anotherParent, "another identifier", "another name", tracks);

            // Act and assert
            Assert.AreEqual(playlist, anotherPlaylist);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void SamePlaylistWithParentAreEqualInReverseOrder()
        {
            // Arrange
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            PlaylistFolder anotherParent = new PlaylistFolder("identifier", "name");
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist(parent, "another identifier", "another name", tracks);
            Playlist anotherPlaylist = new Playlist(anotherParent, "another identifier", "another name", tracks);

            // Act and assert
            Assert.AreEqual(anotherPlaylist, playlist);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TwoPlaylistWithParentNotEqualOnParentAreNotEqual()
        {
            // Arrange
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            PlaylistFolder anotherParent = new PlaylistFolder("another identifier", "name");
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist(parent, "another identifier", "another name", tracks);
            Playlist anotherPlaylist = new Playlist(anotherParent, "another identifier", "another name", tracks);

            // Act and assert
            Assert.AreNotEqual(playlist, anotherPlaylist);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TwoPlaylistWithoutParentNotEqualOnIdentifierAreNotEqual()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);
            Playlist anotherPlaylist = new Playlist("another identifier", "name", tracks);

            // Act and assert
            Assert.AreNotEqual(playlist, anotherPlaylist);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TwoPlaylistWithoutParentNotEqualOnNameAreNotEqual()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);
            Playlist anotherPlaylist = new Playlist("identifier", "another name", tracks);

            // Act and assert
            Assert.AreNotEqual(playlist, anotherPlaylist);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TwoPlaylistWithoutParentNotEqualOnTracksAreNotEqual()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Track[] anotherTracks = new Track[] { new Track(13371337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);
            Playlist anotherPlaylist = new Playlist("identifier", "another name", anotherTracks);

            // Act and assert
            Assert.AreNotEqual(playlist, anotherPlaylist);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void PlaylistAndNullAreNotEqual()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);

            // Act and assert
            Assert.AreNotEqual(playlist, null);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void PlaylistAndStringAreNotEqual()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);

            // Act and assert
            Assert.AreNotEqual(playlist, "Playlist(Parent='', Identifier='identifier', Name='name', Tracks='Track(TrackID='1337', AlbumArtist='Linkin Park', Album='The Hunting Party', TrackNumber='8', Name='Rebellion', Artist='Linkin Park feat. Daron Malakian', Location='M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a')'");
        }

        /// <summary>
        /// Test <see cref="Playlist.GetHashCode()"/> method.
        /// </summary>
        /// <remarks>
        ///     GetHashCode on two equals strings return the same hash code,
        ///     but this hashcode value may be different accross run,
        ///     dotnet implementations and dotnet versions.
        /// </remarks>
        [TestMethod]
        public void HashcodeOfSamePlaylistAreEqual()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Track[] anotherTracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);
            Playlist anotherPlaylist = new Playlist("identifier", "name", anotherTracks);
            int expected = playlist.GetHashCode();

            // Act
            int actual = anotherPlaylist.GetHashCode();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.ToString"/> constructor.
        /// </summary>
        [TestMethod]
        public void PlaylistToStringAndForgedStringAreEqual()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist anotherPlaylist = new Playlist("identifier", "name", tracks);
            string expected = "Playlist(Parent='', Identifier='identifier', Name='name', Tracks='Track(TrackID='1337', AlbumArtist='Linkin Park', Album='The Hunting Party', TrackNumber='8', Name='Rebellion', Artist='Linkin Park feat. Daron Malakian', Location='M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a')')";

            // Act
            string actual = anotherPlaylist.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
