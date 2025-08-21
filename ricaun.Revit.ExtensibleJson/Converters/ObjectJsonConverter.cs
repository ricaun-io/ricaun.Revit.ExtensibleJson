using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ricaun.Revit.ExtensibleJson.Converters
{
    /// <summary>
    /// Provides a base class for custom JSON converters that handle serialization and deserialization
    /// of objects of type <typeparamref name="T"/> using <see cref="JObject"/>.
    /// </summary>
    /// <typeparam name="T">The type of object to convert.</typeparam>
    public abstract class ObjectJsonConverter<T> : JsonConverter
    {
        /// <summary>
        /// Converts the specified <see cref="JObject"/> to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The <see cref="JObject"/> to convert.</param>
        /// <returns>An object of type <typeparamref name="T"/>.</returns>
        public abstract T Read(JObject value);

        /// <summary>
        /// Converts the specified object of type <typeparamref name="T"/> to a serializable object.
        /// </summary>
        /// <param name="value">The object of type <typeparamref name="T"/> to convert.</param>
        /// <returns>A serializable object representation of <paramref name="value"/>.</returns>
        public abstract object Write(T value);

        /// <summary>
        /// Determines whether this converter can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>
        /// <c>true</c> if the object type is equal to <typeparamref name="T"/>; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        /// <summary>
        /// Reads the JSON representation of the object and converts it to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">The type of the object to convert.</param>
        /// <param name="existingValue">The existing value of the object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>An object of type <typeparamref name="T"/>.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return Read(null);
            return Read(JObject.Load(reader));
        }

        /// <summary>
        /// Writes the JSON representation of the object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The object value to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken.FromObject(Write((T)value))
                .WriteTo(writer);
        }
    }
}
