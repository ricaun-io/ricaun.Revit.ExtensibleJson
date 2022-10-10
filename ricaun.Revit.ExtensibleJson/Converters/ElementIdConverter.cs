using Autodesk.Revit.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ricaun.Revit.ExtensibleJson.Converters
{
    /// <summary>
    /// Convert Json to <see cref="Autodesk.Revit.DB.ElementId"/>
    /// </summary>
    public class ElementIdConverter : ObjectJsonConverter<ElementId>
    {
        private const string ElementIdKey = "IntegerValue";

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override ElementId Read(JObject value)
        {
            int id = (int)value[ElementIdKey];
            ElementId elementId = new ElementId(id);

            return elementId;
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override object Write(ElementId value)
        {
            return value;
        }
    }
}
