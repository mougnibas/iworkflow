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
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Track unit test class.
    /// </summary>
    [TestClass]
    public class TrackUnitTest
    {
        /// <summary>
        /// Test the <see cref="Track.TrackID"/> method.
        /// </summary>
        [TestMethod]
        public void TrackIdIs1337()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            int expected = 1337;

            // Act
            int actual = track.TrackID;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.AlbumArtist"/> method.
        /// </summary>
        [TestMethod]
        public void TrackAlbumArtistIsLinkinPark()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            string expected = "Linkin Park";

            // Act
            string actual = track.AlbumArtist;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Album"/> method.
        /// </summary>
        [TestMethod]
        public void TrackAlbumIsTheHuntingParty()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            string expected = "The Hunting Party";

            // Act
            string actual = track.Album;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.TrackNumber"/> method.
        /// </summary>
        [TestMethod]
        public void TrackNumberIs8()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            int expected = 8;

            // Act
            int actual = track.TrackNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Name"/> method.
        /// </summary>
        [TestMethod]
        public void TrackNameIsRebellion()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            string expected = "Rebellion";

            // Act
            string actual = track.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Artist"/> method.
        /// </summary>
        [TestMethod]
        public void TrackArtistIsLinkinParkFeaturingDaronMalakian()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            string expected = "Linkin Park feat. Daron Malakian";

            // Act
            string actual = track.Artist;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Location"/> method.
        /// </summary>
        [TestMethod]
        public void TrackLocationIsOnAGivenRepository()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            string expected = "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a";

            // Act
            string actual = track.Location;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TwoTracksAreEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track anotherTrack = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");

            // Act and Assert
            Assert.AreEqual(track, anotherTrack);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TwoTracksAreEqualInReverseOrder()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track anotherTrack = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");

            // Act and Assert
            Assert.AreEqual(track, anotherTrack);
            Assert.AreEqual(anotherTrack, track);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TrackAndNullAreNotEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");

            // Act and Assert
            Assert.AreNotEqual(track, null);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TrackAndForgedStringAreNotEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            string forged = "A string object";

            // Act and Assert
            Assert.AreNotEqual(track, forged);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TwoTracksNotEqualOnTrackIdAreNotEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track newReference = new Track(1336, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");

            // Act and Assert
            Assert.AreNotEqual(track, newReference);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TwoTracksNotEqualOnAlbumArtistAreNotEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track newReference = new Track(1337, "Linkin Parkkk", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");

            // Act and Assert
            Assert.AreNotEqual(track, newReference);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TwoTracksNotEqualOnAlbumAreNotEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track newReference = new Track(1337, "Linkin Park", "The Hunting Partyyyy", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");

            // Act and Assert
            Assert.AreNotEqual(track, newReference);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TwoTracksNotEqualOnTrackNumberAreNotEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track newReference = new Track(1337, "Linkin Park", "The Hunting Party", 9, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");

            // Act and Assert
            Assert.AreNotEqual(track, newReference);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TwoTracksNotEqualOnNameAreNotEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellionnn", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");

            // Act and Assert
            Assert.AreNotEqual(track, newReference);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TwoTracksNotEqualOnArtistAreNotEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian and me", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");

            // Act and Assert
            Assert.AreNotEqual(track, newReference);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TwoTracksNotEqualOnLocationAreNotEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4aaa");

            // Act and Assert
            Assert.AreNotEqual(track, newReference);
        }

        /// <summary>
        /// Test <see cref="Track.GetHashCode()"/> method.
        /// </summary>
        /// <remarks>
        ///     GetHashCode on two equals strings return the same hash code,
        ///     but this hashcode value may be different accross run,
        ///     dotnet implementations and dotnet versions.
        /// </remarks>
        [TestMethod]
        public void HashcodeOfSameTracksAreEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Track newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            int expected = newReference.GetHashCode();

            // Act
            int actual = track.GetHashCode();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Track.ToString()"/> method.
        /// </summary>
        [TestMethod]
        public void TrackToStringAndForgedStringAreEqual()
        {
            // Arrange
            Track track = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            string expected = "Track(TrackID='1337', AlbumArtist='Linkin Park', Album='The Hunting Party', TrackNumber='8', Name='Rebellion', Artist='Linkin Park feat. Daron Malakian', Location='M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a')";

            // Act
            string actual = track.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
