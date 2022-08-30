using Newtonsoft.Json;
using ricaun.Revit.ExtensibleJson.Converters;

namespace ricaun.Revit.ExtensibleJson
{
    /// <summary>
    /// JsonService
    /// </summary>
    public class JsonService : JsonService<object>, IJsonService
    {

    }

    /// <summary>
    /// JsonService
    /// </summary>
    /// <typeparam name="TJson"></typeparam>
    public class JsonService<TJson> : IJsonService<TJson>
    {
        private readonly JsonSerializerSettings settings;
        /// <summary>
        /// JsonService
        /// </summary>
        public JsonService()
        {
            settings = new JsonSerializerSettings();
            settings.Converters.Add(new ElementIdConverter());
            settings.Converters.Add(new XYZConverter());
        }

        /// <summary>
        /// Get JsonSerializerSettings
        /// </summary>
        /// <returns></returns>
        public JsonSerializerSettings GetSettings() => settings;

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Serialize(TJson value)
        {
            return SerializeObject<TJson>(value);
        }

        /// <summary>
        /// SerializeObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public string SerializeObject<T>(T value)
        {
            return JsonConvert.SerializeObject(value, settings);
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TJson Deserialize(string value)
        {
            return DeserializeObject<TJson>(value);
        }

        /// <summary>
        /// DeserializeObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, settings);
        }
    }
}