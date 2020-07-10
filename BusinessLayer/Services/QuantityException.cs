//-----------------------------------------------------------------------
// <copyright file="QuantityException.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace BusinessLayer
{
    using System;

    /// <summary>
    /// class extending Exception class properties
    /// </summary>
    [Serializable]
    public class QuantityException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityException" /> class.
        /// </summary>
        public QuantityException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityException" /> class.
        /// </summary>
        /// <param name="type">Type of Exception</param>
        /// <param name="message">Exception message</param>
        public QuantityException(ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }

        /// <summary>
        /// enum specifying Invalid Length
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// for Invalid Data
            /// </summary>
            InvalidData
        }

        /// <summary>
        /// Gets or sets for Exception type
        /// </summary>
        public ExceptionType Type { get; set; }
    }
}