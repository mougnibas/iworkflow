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
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.MusicWorkflow.Database;

    /// <summary>
    /// Track unit test class.
    /// </summary>
    [TestClass]
    public class TrackUnitTest
    {
        /// <summary>
        /// The class instance to test.
        /// </summary>
        private Track toTest;

        /// <summary>
        /// Invoke this method before each test method.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            // Instantiate the class to test
            this.toTest = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
        }

        /// <summary>
        /// Test the <see cref="Track.TrackID"/> method.
        /// </summary>
        [TestMethod]
        public void TestTrackID()
        {
            int expected = 1337;
            int actual = this.toTest.TrackID;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.AlbumArtist"/> method.
        /// </summary>
        [TestMethod]
        public void TestAlbumArtist()
        {
            string expected = "Linkin Park";
            string actual = this.toTest.AlbumArtist;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Album"/> method.
        /// </summary>
        [TestMethod]
        public void TestAlbum()
        {
            string expected = "The Hunting Party";
            string actual = this.toTest.Album;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.TrackNumber"/> method.
        /// </summary>
        [TestMethod]
        public void TestTrackNumber()
        {
            int expected = 8;
            int actual = this.toTest.TrackNumber;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Name"/> method.
        /// </summary>
        [TestMethod]
        public void TestName()
        {
            string expected = "Rebellion";
            string actual = this.toTest.Name;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Artist"/> method.
        /// </summary>
        [TestMethod]
        public void TestArtist()
        {
            string expected = "Linkin Park feat. Daron Malakian";
            string actual = this.toTest.Artist;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Location"/> method.
        /// </summary>
        [TestMethod]
        public void TestLocation()
        {
            string expected = "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a";
            string actual = this.toTest.Location;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEquals()
        {
            var newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Assert.AreEqual(newReference, this.toTest);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestEqualsReverse()
        {
            var newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Assert.AreEqual(this.toTest, newReference);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnNull()
        {
            Assert.AreNotEqual(this.toTest, null);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnAnotherType()
        {
            Assert.AreNotEqual(this.toTest, "A string object");
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnTrackId()
        {
            var newReference = new Track(1336, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Assert.AreNotEqual(newReference, this.toTest);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnAlbumArtist()
        {
            var newReference = new Track(1337, "Linkin Parkkk", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Assert.AreNotEqual(newReference, this.toTest);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnAlbum()
        {
            var newReference = new Track(1337, "Linkin Park", "The Hunting Partyyyy", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Assert.AreNotEqual(newReference, this.toTest);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnTrackNumber()
        {
            var newReference = new Track(1337, "Linkin Park", "The Hunting Party", 9, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Assert.AreNotEqual(newReference, this.toTest);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnName()
        {
            var newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellionnn", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Assert.AreNotEqual(newReference, this.toTest);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnArtist()
        {
            var newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian and me", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            Assert.AreNotEqual(newReference, this.toTest);
        }

        /// <summary>
        /// Test the <see cref="Track.Equals(object)"/> method.
        /// </summary>
        [TestMethod]
        public void TestNotEqualsOnLocation()
        {
            var newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4aaa");
            Assert.AreNotEqual(newReference, this.toTest);
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
        public void TestGetHashCode()
        {
            var newReference = new Track(1337, "Linkin Park", "The Hunting Party", 8, "Rebellion", "Linkin Park feat. Daron Malakian", "M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a");
            int expected = newReference.GetHashCode();
            int actual = this.toTest.GetHashCode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test <see cref="Track.ToString()"/> method.
        /// </summary>
        [TestMethod]
        public void TestToString()
        {
            string expected = "Track(TrackID='1337', AlbumArtist='Linkin Park', Album='The Hunting Party', TrackNumber='8', Name='Rebellion', Artist='Linkin Park feat. Daron Malakian', Location='M:\\repo\\Linkin Park\\The Hunting Party\\1-08 Rebellion.m4a')";
            string actual = this.toTest.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
