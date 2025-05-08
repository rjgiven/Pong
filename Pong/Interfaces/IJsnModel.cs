using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Pong.Interfaces
{
    /// <summary>
    /// Provide json conversion functions.
    /// </summary>
    public interface IJsnModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Used to serialize the object into a json string.
        /// </summary>
        /// <remarks>
        /// This function is used in conjunction with the <see cref="FromJson(string)"/> method to convert
        /// the object to and from json.
        /// </remarks>
        /// <returns> A string value representing the json version of the object.</returns>
        /// <param name="formatting">Indicates how the output should be formatted.</param>
        string ToJson(Formatting formatting = Formatting.None);

        /// <summary>
        /// Used to populate the current instance of <see cref="BaseModel"/> from a json string.
        /// </summary>
        /// <remarks>
        /// This function is used in conjunction with the <see cref="ToJson(Formatting)"/> method to convert
        /// the object to and from json.  This method will throw if the json is invalid.
        /// </remarks>
        /// <param name="json">The json string to convert.</param>
        void FromJson(string json);

        /// <summary>
        /// Serialize the object to json and write it to a stream.
        /// </summary>
        void ToStream(Stream stream);

        /// <summary>
        /// Preserve the State of the object so that is can be restored or easily checked for changes if needed.
        /// </summary>
        void PreserveState();

        /// <summary>
        /// Return the properties of the object to the values last saved using the PreserveState call.
        /// This should throw if PreserveState has not been called.
        /// </summary>
        void RestoreState();

        /// <summary>
        /// Determine if the object has changed singce the last PreserveState call.
        /// This should always return true if PreserveState has not been called.
        /// </summary>
        /// <returns>A boolean indicating whether any of the properties have changed.</returns>
        bool IsDirty();

    }
}
