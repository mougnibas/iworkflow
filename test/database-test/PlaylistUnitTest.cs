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

namespace Mougnibas.MusicWorkflow.Database.Test
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.MusicWorkflow.Database;

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
        public void TestPlaylistWithParentConstructorOnParent()
        {
            // Arrange
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, "another identifier", "another name", Array.Empty<Track>());

            // Act
            PlaylistFolder expected = parent;
            PlaylistFolder actual = playlist.Parent;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(PlaylistFolder, string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestPlaylistWithParentConstructorOnIdentifier()
        {
            // Arrange
            string identifier = "another identifier";
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, identifier, "another name", Array.Empty<Track>());

            // Act
            string expected = identifier;
            string actual = playlist.Identifier;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(PlaylistFolder, string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestPlaylistWithParentConstructorOnName()
        {
            // Arrange
            string name = "another name";
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, "another identifier", name, Array.Empty<Track>());

            // Act
            string expected = name;
            string actual = playlist.Name;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(PlaylistFolder, string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestPlaylistWithParentConstructorOnTracks()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, "another identifier", "another name", tracks);

            // Act
            ReadOnlyCollection<Track> expected = new ReadOnlyCollection<Track>(tracks);
            ReadOnlyCollection<Track> actual = playlist.Tracks;

            // Assert
            CollectionAssert.Equals(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestPlaylistWithoutParentConstructorOnIdentifier()
        {
            // Arrange
            string identifier = "another identifier";
            Playlist playlist = new Playlist(identifier, "another name", Array.Empty<Track>());

            // Act
            string expected = identifier;
            string actual = playlist.Identifier;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestPlaylistWithoutParentConstructorOnName()
        {
            // Arrange
            string name = "another name";
            Playlist playlist = new Playlist("another identifier", name, Array.Empty<Track>());

            // Act
            string expected = name;
            string actual = playlist.Name;

            // Assert
            Assert.AreSame(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Playlist(string, string, Track[])"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestPlaylistWithoutParentConstructorOnTracks()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("another identifier", "another name", tracks);

            // Act
            ReadOnlyCollection<Track> expected = new ReadOnlyCollection<Track>(tracks);
            ReadOnlyCollection<Track> actual = playlist.Tracks;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Parent"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestParent()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            PlaylistFolder parent = new PlaylistFolder("identifier", "name");
            Playlist playlist = new Playlist(parent, "another identifier", "another name", tracks);

            // Act
            PlaylistFolder expected = parent;
            PlaylistFolder actual = playlist.Parent;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Identifier"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestIdentifier()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);

            // Act
            string expected = "identifier";
            string actual = playlist.Identifier;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Name"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestName()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);

            // Act
            string expected = "name";
            string actual = playlist.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Tracks"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestTracks()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("another identifier", "another name", tracks);

            // Act
            ReadOnlyCollection<Track> expected = new ReadOnlyCollection<Track>(tracks);
            ReadOnlyCollection<Track> actual = playlist.Tracks;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.Equals(object)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestEquals()
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
        public void TestEqualsReverse()
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
        public void TestEqualsWithParent()
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
        public void TestEqualsWithParentReverse()
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
        public void TestNotEqualsOnParent()
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
        public void TestNotEqualsOnIdentifier()
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
        public void TestNotEqualsOnName()
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
        public void TestNotEqualsOnTracks()
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
        public void TestNotEqualsOnNull()
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
        public void TestNotEqualsOnAnotherType()
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
        public void TestGetHashCode()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Track[] anotherTracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);
            Playlist anotherPlaylist = new Playlist("identifier", "name", anotherTracks);

            // Act
            int expected = playlist.GetHashCode();
            int actual = anotherPlaylist.GetHashCode();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Playlist.ToString"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            // Arrange
            Track[] tracks = new Track[] { new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a") };
            Playlist playlist = new Playlist("identifier", "name", tracks);
            Playlist anotherPlaylist = new Playlist("identifier", "name", tracks);

            // Act
            string expected = "Playlist(Parent='', Identifier='identifier', Name='name', Tracks='Track(TrackID='1337', AlbumArtist='Linkin Park', Album='The Hunting Party', TrackNumber='8', Name='Rebellion', Artist='Linkin Park feat. Daron Malakian', Location='M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a')')";
            string actual = anotherPlaylist.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
