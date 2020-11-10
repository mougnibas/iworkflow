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

namespace Mougnibas.MusicWorkflow.Provider.Fake.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.MusicWorkflow.Contract.Model;
    using Mougnibas.MusicWorkflow.Contract.Service;
    using Mougnibas.MusicWorkflow.Provider.Fake;

    /// <summary>
    /// FakeMusicServiceUnitTest unit test class.
    /// </summary>
    [TestClass]
    public class FakeMusicServiceUnitTest
    {
        /// <summary>
        /// Test the <see cref="FakeMusicService.FakeMusicService()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateDontThrowException()
        {
            // Arrange and act (Assert is done by not defining an expected exception)
            IMusicService service = new FakeMusicService();
        }

        /// <summary>
        /// Test the <see cref="FakeMusicService.GetTracks()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateThenInitThenGetTracksReturn8Tracks()
        {
            // Arrange
            IMusicService service = new FakeMusicService();
            service.Init();
            int expected = 8;

            // Act
            int actual = service.GetTracks().Length;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="FakeMusicService.GetPlaylistFolders()"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateThenInitThenGetPlaylistFoldersReturnYoann()
        {
            // Arrange
            IMusicService service = new FakeMusicService();
            service.Init();
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
            PlaylistFolder actual = service.GetPlaylistFolders()[0];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="FakeMusicService.GetPlaylistFolder(string)"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateThenInitThenGetPlaylistFolderByIdWithADACB1B93A6C37C3ReturnYoann()
        {
            // Arrange
            IMusicService service = new FakeMusicService();
            service.Init();
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
            PlaylistFolder actual = service.GetPlaylistFolder("ADACB1B93A6C37C3");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="FakeMusicService.GetPlaylist(string)"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateThenInitThenGetPlaylistByIdWith88A4FA1A260043F3ReturnMyAwesomeTLOZPlaylist()
        {
            // Arrange
            IMusicService service = new FakeMusicService();
            service.Init();
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
            PlaylistFolder playlistFolder = new PlaylistFolder("ADACB1B93A6C37C3", "Yoann");
            Playlist expected = new Playlist(playlistFolder, "88A4FA1A260043F3", "My awesome TLOZ playlist", tracks);
            playlistFolder.Add(expected);

            // Act
            Playlist actual = service.GetPlaylist("88A4FA1A260043F3");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the <see cref="FakeMusicService.GetPlaylistFolder(string)"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateThenInitThenGetPlaylistFolderByIdWithIDontExistReturnNull()
        {
            // Arrange
            IMusicService service = new FakeMusicService();
            service.Init();

            // Act
            PlaylistFolder nullReference = service.GetPlaylistFolder("I don't exist");

            // Assert
            Assert.IsNull(nullReference);
        }

        /// <summary>
        /// Test the <see cref="FakeMusicService.GetPlaylist(string)"/> constructor.
        /// </summary>
        [TestMethod]
        public void InstantiateThenInitThenGetPlaylistByIdWithIDontExistReturnNull()
        {
            // Arrange
            IMusicService service = new FakeMusicService();
            service.Init();

            // Act
            Playlist nullReference = service.GetPlaylist("I don't exist");

            // Assert
            Assert.IsNull(nullReference);
        }
    }
}
