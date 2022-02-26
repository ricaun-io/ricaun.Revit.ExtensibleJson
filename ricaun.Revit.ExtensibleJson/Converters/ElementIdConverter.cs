using Autodesk.Revit.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ricaun.Revit.ExtensibleJson.Converters
{
    /// <summary>
    /// Convert Json to <see cref="Autodesk.Revit.DB.ElementId"/>
    /// </summary>
    public class ElementIdConverter : JsonConverter
    {
        private const string ElementIdKey = "IntegerValue";

        /// <summary>
        /// Check type equal to <see cref="Autodesk.Revit.DB.ElementId"/>
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ElementId);
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
            JObject jObject = JObject.Load(reader);

            int id = (int)jObject[ElementIdKey];
            ElementId elementId = new ElementId(id);

            return elementId;
        }

        /// <summary>
        /// WriteJson
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);
            t.WriteTo(writer);
        }
    }
}
