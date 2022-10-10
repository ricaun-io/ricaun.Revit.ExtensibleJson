using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ricaun.Revit.ExtensibleJson.Converters
{
    /// <summary>
    /// ObjectJsonConverter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ObjectJsonConverter<T> : JsonConverter
    {
        /// <summary>
        /// Convert <paramref name="value"/> to <typeparamref name="T"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract T Read(JObject value);

        /// <summary>
        /// Convert <paramref name="value"/> to object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract object Write(T value);

        /// <summary>
        /// Check type equal to <typeparamref name="T"/>
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        /// <summary>
        /// ReadJson
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return Read(JObject.Load(reader));
        }

        /// <summary>
        /// WriteJson
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken.FromObject(Write((T)value))
                .WriteTo(writer);
        }
    }
}
