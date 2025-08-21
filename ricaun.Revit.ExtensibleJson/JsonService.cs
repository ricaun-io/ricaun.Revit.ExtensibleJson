using Newtonsoft.Json;
using ricaun.Revit.ExtensibleJson.Converters;

namespace ricaun.Revit.ExtensibleJson
{
    /// <summary>
    /// Provides JSON serialization and deserialization services using default settings and custom converters.
    /// </summary>
    /// <remarks>
    /// This class is a non-generic implementation of <see cref="JsonService{TJson}"/> for <see cref="object"/> type.
    /// It implements <see cref="IJsonService"/> for convenience.
    /// </remarks>
    public class JsonService : JsonService<object>, IJsonService
    {

    }

    /// <summary>
    /// Provides JSON serialization and deserialization services for a specific type using custom converters.
    /// </summary>
    /// <typeparam name="TJson">The type to serialize and deserialize.</typeparam>
    public class JsonService<TJson> : IJsonService<TJson>
    {
        private readonly JsonSerializerSettings settings;
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonService{TJson}"/> class with default settings and custom converters.
        /// </summary>
        public JsonService()
        {
            settings = new JsonSerializerSettings();
            settings.Converters.Add(new ElementIdConverter());
            settings.Converters.Add(new XYZConverter());
        }

        /// <summary>
        /// Gets the <see cref="JsonSerializerSettings"/> used for serialization and deserialization.
        /// </summary>
        /// <returns>The <see cref="JsonSerializerSettings"/> instance.</returns>
        public JsonSerializerSettings GetSettings() => settings;

        /// <summary>
        /// Serializes the specified value to a JSON string.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <returns>A JSON string representation of the value.</returns>
        public string Serialize(TJson value)
        {
            return SerializeObject<TJson>(value);
        }

        /// <summary>
        /// Serializes the specified value of type <typeparamref name="T"/> to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the value to serialize.</typeparam>
        /// <param name="value">The value to serialize.</param>
        /// <returns>A JSON string representation of the value.</returns>
        public string SerializeObject<T>(T value)
        {
            return JsonConvert.SerializeObject(value, settings);
        }

        /// <summary>
        /// Deserializes the specified JSON string to an object of type <typeparamref name="TJson"/>.
        /// </summary>
        /// <param name="value">The JSON string to deserialize.</param>
        /// <returns>An object of type <typeparamref name="TJson"/>.</returns>
        public TJson Deserialize(string value)
        {
            return DeserializeObject<TJson>(value);
        }

        /// <summary>
        /// Deserializes the specified JSON string to an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize to.</typeparam>
        /// <param name="value">The JSON string to deserialize.</param>
        /// <returns>An object of type <typeparamref name="T"/>.</returns>
        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, settings);
        }
    }
}