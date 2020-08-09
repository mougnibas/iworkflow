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

namespace Mougnibas.MusicWorkflow.ITunesLibraryXMLParser.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.MusicWorkflow.Database;
    using Mougnibas.MusicWorkflow.ITunesLibraryXMLParser.Exceptions;

    /// <summary>
    /// Parser unit test class.
    /// </summary>
    [TestClass]
    public class ParserUnitTest
    {
        /// <summary>
        /// Test the <see cref="Parser.Parser()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateEmptyConstructorReturnDefaultPath()
        {
            // Arrange
            Parser parser = new Parser();
            string expected = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic) + "\\iTunes\\iTunes Music Library.xml";

            // Act
            var actual = parser.Path;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.Parser(string)"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateWithPathReturnSamePath()
        {
            // Arrange
            Parser parser = new Parser("iTunes Music Library.xml");
            string expected = "iTunes Music Library.xml";

            // Act
            string actual = parser.Path;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.LoadAndParse()"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(XmlFileReadException))]
        public void InstantiateParserWithInvalidPathThenInvokeLoadAndParseShouldReturnAnException()
        {
            // Arrange
            Parser parser = new Parser("this file does not exist");

            // Act (assert part is in test method declaration tag)
            parser.LoadAndParse();
        }

        /// <summary>
        /// Test the <see cref="Parser.LoadAndParse()"/> method.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturn8Tracks()
        {
            // Arrange
            Parser parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            int expected = 8;

            // Act
            int actual = parser.GetTracks().Length;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetTracks()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnAGivenTrackAtIndex0()
        {
            // Arrange
            Parser parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            Track expected = new Track(80, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 1, "The Legend Of Zelda 25th Anniversary Medley", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/01%20The%20Legend%20Of%20Zelda%2025th%20Annivers.m4a");

            // Act
            Track actual = parser.GetTracks()[0];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetTracks()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnAGivenTrackAtIndex1()
        {
            // Arrange
            Parser parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            Track expected = new Track(82, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 2, "Kakariko Village (Twilight Princess Theme)", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/02%20Kakariko%20Village%20(Twilight%20Prince.m4a");

            // Act
            Track actual = parser.GetTracks()[1];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetTracks()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnAGivenTrackAtIndex2()
        {
            // Arrange
            Parser parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            Track expected = new Track(84, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 3, "The Wind Waker Symphonic Movement", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/03%20The%20Wind%20Waker%20Symphonic%20Movement.m4a");

            // Act
            Track actual = parser.GetTracks()[2];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetTracks()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnAGivenTrackAtIndex3()
        {
            // Arrange
            Parser parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            Track expected = new Track(86, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 4, "Gerudo Valley", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/04%20Gerudo%20Valley.m4a");

            // Act
            Track actual = parser.GetTracks()[3];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetTracks()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnAGivenTrackAtIndex4()
        {
            // Arrange
            Parser parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            Track expected = new Track(88, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 5, "Great Fairy's Fountain Theme", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/05%20Great%20Fairy's%20Fountain%20Theme.m4a");

            // Act
            Track actual = parser.GetTracks()[4];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetTracks()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnAGivenTrackAtIndex5()
        {
            // Arrange
            Parser parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            Track expected = new Track(90, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 6, "Twilight Princess Symphonic Movement", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/06%20Twilight%20Princess%20Symphonic%20Movem.m4a");

            // Act
            Track actual = parser.GetTracks()[5];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetTracks()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnAGivenTrackAtIndex6()
        {
            // Arrange
            Parser parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            Track expected = new Track(92, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 7, "The Legend Of Zelda Main Theme Medley", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/07%20The%20Legend%20Of%20Zelda%20Main%20Theme%20Me.m4a");

            // Act
            Track actual = parser.GetTracks()[6];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetTracks()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnAGivenTrackAtIndex7()
        {
            // Arrange
            Parser parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            Track expected = new Track(94, "Koji Kondo", "The Legend Of Zelda 25th Anniversary Special Orchestra CD", 8, "Ballad Of The Goddess From Skyward Sword", "Koji Kondo", "file://localhost/C:/Users/Yoann/Music/iTunes/iTunes%20Media/Music/Koji%20Kondo/The%20Legend%20Of%20Zelda%2025th%20Anniversary%20Spe/08%20Ballad%20Of%20The%20Goddess%20From%20Skywar.m4a");

            // Act
            Track actual = parser.GetTracks()[7];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetPlaylistFolders()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnYoannName()
        {
            // Arrange
            var parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            string expected = "Yoann";

            // Act
            string actual = parser.GetPlaylistFolders()[0].Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetPlaylistFolders()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnADACB1B93A6C37C3Identifier()
        {
            // Arrange
            var parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
            string expected = "ADACB1B93A6C37C3";

            // Act
            string actual = parser.GetPlaylistFolders()[0].Identifier;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="Parser.GetPlaylistFolders()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateParserWithValidPathThenInvokeLoadAndParseShouldReturnThisPlaylistFolder()
        {
            // Arrange
            var parser = new Parser("../../../iTunes Music Library.xml");
            parser.LoadAndParse();
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
            PlaylistFolder expected = new PlaylistFolder("ADACB1B93A6C37C3", "Yoann");
            Playlist playlist = new Playlist(expected, "88A4FA1A260043F3", "My awesome TLOZ playlist", tracks);
            expected.Add(playlist);

            // Act
            PlaylistFolder actual = parser.GetPlaylistFolders()[0];

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
