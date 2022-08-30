using Autodesk.Revit.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ricaun.Revit.ExtensibleJson.Converters
{
    /// <summary>
    /// Convert Json to <see cref="Autodesk.Revit.DB.XYZ"/>
    /// </summary>
    public class XYZConverter : JsonConverter
    {
        private const string XKey = "X";
        private const string YKey = "Y";
        private const string ZKey = "Z";

        /// <summary>
        /// Check type equal to <see cref="Autodesk.Revit.DB.XYZ"/>
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(XYZ);
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

            double x = (double)jObject[XKey];
            double y = (double)jObject[YKey];
            double z = (double)jObject[ZKey];
            XYZ xyz = new XYZ(x, y, z);

            return xyz;
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
