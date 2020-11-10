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

namespace Mougnibas.MusicWorkflow.UI.Test
{
    using Bunit;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mougnibas.MusicWorkflow.UI.Pages;

    /// <summary>
    /// Blazor Index test class.
    /// </summary>
    [TestClass]
    public class IndexPageUnitTest
    {
        /// <summary>
        /// Test the <see cref="IndexPage"/> blazor component.
        /// </summary>
        [TestMethod]
        public void MustRenderIndexContent()
        {
            // Arrange
            using var context = new Bunit.TestContext();
            string expected = "<p>This is the index page.</p><p>You can go <a href=\"/playlistfolders\">there</a>.</p>";

            // Act
            var componentUnderTest = context.RenderComponent<IndexPage>();

            // Assert (will throw an exception if it don't match)
            componentUnderTest.MarkupMatches(expected);
        }
    }
}
