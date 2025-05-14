using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;
using Pong.Interfaces;

namespace Pong.Classes
{
    public class JsnModel : IJsnModel, IEquatable<JsnModel>, INotifyPropertyChanged
    {
        #region Json Conversions

        /// <summary>
        /// ToJson is used to serialize the object into a json string.
        /// </summary>
        /// <remarks>
        /// This function is used in conjunction with the FromJson method to convert
        /// the object to and from json.
        /// </remarks>
        /// <returns> A string value representing the json version of the object.</returns>
        /// <param name="formatting">Indicates how the output should be formatted.</param>
        public virtual string ToJson(Formatting formatting = Formatting.None) { return JsonConvert.SerializeObject(this, formatting); }

        /// <summary>
        /// FromJson is used to populate the current instance of BaseModel from a json string.
        /// </summary>
        /// <remarks>
        /// This function is used in conjunction with the ToJson method to convert
        /// the object to and from json.  This method will throw if the json is invalid.
        /// </remarks>
        /// <param name="json">The json string to convert.</param>
        public virtual void FromJson(string json)
        {
            try
            {
                JsonConvert.PopulateObject(json, this);
                //return this;
            }
            catch (Exception e)
            {
                throw new Exception("Unable to populate the current object from json string.", e);
            }
        }

        /// <summary>
        /// FromJson is used to populate an existing instance of BaseModel from a json string.
        /// </summary>
        /// <remarks>
        /// This function is used in conjunction with the ToJson method to convert
        /// the object to and from json.  This method will throw if the json is invalid.
        /// </remarks>
        /// <param name="json">The json string to convert.</param>
        /// <param name="exisitng_object">The existing object to populate.</param>
        public static void FromJson(string json, object exisitng_object)
        {
            try
            {
                JsonConvert.PopulateObject(json, exisitng_object);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to populate the existing object from json string.", e);
            }
        }

        /// <summary>
        /// Serialize the object to json and write it to a stream.
        /// </summary>
        public void ToStream(Stream stream)
        {
            using (StreamWriter writer = new StreamWriter(stream, Encoding.ASCII, 4096, true))
            {
                using (JsonTextWriter json_writer = new JsonTextWriter(writer))
                {
                    JsonSerializer ser = new JsonSerializer();
                    ser.Serialize(json_writer, this);
                    json_writer.Flush();
                }
            }
        }

        #endregion

        #region Static Helpers

        /// <summary>
        /// FromJson is used to create an instance of an object that extends from BaseModel from a json string.
        /// </summary>
        /// <remarks>
        /// This function is used in conjunction with the ToJson method to convert
        /// the object to and from json.  This method will throw if the json is invalid.
        /// DO NOT Force the type Dave ... this will break stored procedures.
        /// </remarks>
        /// <returns> An object of type T that was created from the json string.</returns>
        /// <param name="json">The json string to convert.</param>
        public static T FromJson<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to create '{typeof(T)}' from json string.", e);
            }
        }

        /// <summary>
        /// Create an instance of an object from a source dictionary.
        /// </summary>
        /// <param name="src">The source dictionary.</param>
        /// <returns>An object of type T that was saved in the source dictionary.</returns>
        public static T FromDictionary<T>(IDictionary<string, string> src) where T : IJsnModel
        {
            string key = typeof(T).Name;
            if (src.ContainsKey(key))
            {
                return FromJson<T>(src[key]);
            }
            return default;
        }

        /// <summary>
        /// Create an instance of an object from a memory stream.
        /// </summary>
        /// <param name="stream">The source stream.</param>
        /// <returns>An object of type T that was created from the stream.</returns>
        public static T FromStream<T>(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream, Encoding.ASCII, false, 4096, true))
            {
                using (JsonTextReader json_reader = new JsonTextReader(reader))
                {
                    JsonSerializer ser = new JsonSerializer();
                    return (T)ser.Deserialize(json_reader, typeof(T));
                }
            }
        }

        #endregion

        #region State

        /// <summary>
        /// A value used to track the state of the object when used in a data entry UI.
        /// </summary>
        protected string SavedState = "";

        /// <summary>
        /// Preserve the State of the object so that is can be restored or easily checked for changes if needed.
        /// </summary>
        public void PreserveState() { SavedState = ToJson(); }

        /// <summary>
        /// REturn the properties of the object to the values last saved using the PreserveState call.
        /// This will throw if PreserveState has not been called.
        /// </summary>
        public void RestoreState()
        {
            if (SavedState == "")
            {
                throw new Exception("Must call PreserveState before RestoreState is called.");
            }
            FromJson(SavedState);
        }

        /// <summary>
        /// Determine if the object has changed since the last PreserveState call.
        /// This will always return true if PreserveState has not been called.
        /// </summary>
        /// <returns>A boolean indicating whether any of the properties have changed.</returns>
        public bool IsDirty() { return !Equals(SavedState); }

        #endregion

        #region IEquatable<BaseModel>

        /// <summary>
        /// Compare the json strings of the two objects to see if they are the same.
        /// </summary>
        public bool Equals(JsnModel other)
        {
            return ToJson().Equals(other.ToJson());
        }

        #endregion

        #region INotifyPropertyChanged

        /// <summary>
        /// This event allows for notification of a property changing to things that need to listen for that.
        /// </summary>
        /// <remarks>
        /// An example of this is a UI interface that needs to update when a specific property is changed.
        /// </remarks>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// A helper to fire the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <remarks>
        /// This is made public so a view model can call it on any <see cref="JsnModel"/> property if needed.
        /// </remarks>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}