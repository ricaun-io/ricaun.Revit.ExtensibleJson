using Autodesk.Revit.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ricaun.Revit.ExtensibleJson.Converters
{
    /// <summary>
    /// Convert Json to <see cref="Autodesk.Revit.DB.XYZ"/>
    /// </summary>
    public class XYZConverter : ObjectJsonConverter<XYZ>
    {
        private const string XKey = "X";
        private const string YKey = "Y";
        private const string ZKey = "Z";

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override XYZ Read(JObject value)
        {
            double x = (double)value[XKey];
            double y = (double)value[YKey];
            double z = (double)value[ZKey];
            XYZ xyz = new XYZ(x, y, z);
            return xyz;
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object Write(XYZ value)
        {
            return value;
        }



        ///// <summary>
        ///// WriteJson
        ///// </summary>
        ///// <param name="writer"></param>
        ///// <param name="value"></param>
        ///// <param name="serializer"></param>
        //public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //{
        //    JToken t = JToken.FromObject(value);
        //    t.WriteTo(writer);
        //}
    }

}
