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

namespace Mougnibas.MusicWorkflow.Provider.AppleMusicService.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception about a XML file which can not be read.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class XmlFileReadException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlFileReadException"/> class.
        /// </summary>
        public XmlFileReadException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlFileReadException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public XmlFileReadException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlFileReadException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The inner exception.</param>
        public XmlFileReadException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlFileReadException"/> class.
        /// </summary>
        /// <param name="info">Serialisation information.</param>
        /// <param name="context">Streaming context.</param>
        protected XmlFileReadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
