using Newtonsoft.Json;

namespace ricaun.Revit.ExtensibleJson
{
    /// <summary>
    /// Provides methods for serializing and deserializing JSON data.
    /// </summary>
    public interface IJsonService : IJsonService<object>
    {

    }

    /// <summary>
    /// Defines a service for JSON serialization and deserialization for a specific type.
    /// </summary>
    /// <typeparam name="TJson">The type to serialize or deserialize.</typeparam>
    public interface IJsonService<TJson>
    {
        /// <summary>
        /// Gets the <see cref="JsonSerializerSettings"/> used for serialization and deserialization.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonSerializerSettings"/> instance.
        /// </returns>
        JsonSerializerSettings GetSettings();

        /// <summary>
        /// Serializes the specified value to a JSON string.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>
        /// A JSON string representation of the value.
        /// </returns>
        string Serialize(TJson value);

        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="value">The object to serialize.</param>
        /// <returns>
        /// A JSON string representation of the object.
        /// </returns>
        string SerializeObject<T>(T value);

        /// <summary>
        /// Deserializes the specified JSON string to an object of type <typeparamref name="TJson"/>.
        /// </summary>
        /// <param name="value">The JSON string to deserialize.</param>
        /// <returns>
        /// An object of type <typeparamref name="TJson"/> deserialized from the JSON string.
        /// </returns>
        TJson Deserialize(string value);

        /// <summary>
        /// Deserializes the specified JSON string to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="value">The JSON string to deserialize.</param>
        /// <returns>
        /// An object of type <typeparamref name="T"/> deserialized from the JSON string.
        /// </returns>
        T DeserializeObject<T>(string value);
    }
}