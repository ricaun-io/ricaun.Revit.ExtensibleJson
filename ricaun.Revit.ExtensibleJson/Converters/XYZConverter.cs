using Autodesk.Revit.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ricaun.Revit.ExtensibleJson.Converters
{
    /// <summary>
    /// Converts JSON objects to and from <see cref="Autodesk.Revit.DB.XYZ"/> instances.
    /// </summary>
    public class XYZConverter : ObjectJsonConverter<XYZ>
    {
        /// <summary>
        /// The JSON key for the X coordinate.
        /// </summary>
        private const string XKey = "X";
        /// <summary>
        /// The JSON key for the Y coordinate.
        /// </summary>
        private const string YKey = "Y";
        /// <summary>
        /// The JSON key for the Z coordinate.
        /// </summary>
        private const string ZKey = "Z";

        /// <summary>
        /// Reads a <see cref="JObject"/> and converts it to an <see cref="Autodesk.Revit.DB.XYZ"/> instance.
        /// </summary>
        /// <param name="value">The <see cref="JObject"/> containing the XYZ data.</param>
        /// <returns>An <see cref="Autodesk.Revit.DB.XYZ"/> instance with the values from the JSON object.</returns>
        public override XYZ Read(JObject value)
        {
            double x = (double)value[XKey];
            double y = (double)value[YKey];
            double z = (double)value[ZKey];
            XYZ xyz = new XYZ(x, y, z);
            return xyz;
        }

        /// <summary>
        /// Converts an <see cref="Autodesk.Revit.DB.XYZ"/> instance to an object suitable for JSON serialization.
        /// </summary>
        /// <param name="value">The <see cref="Autodesk.Revit.DB.XYZ"/> instance to convert.</param>
        /// <returns>An object representing the XYZ data for serialization.</returns>
        public override object Write(XYZ value)
        {
            return value;
        }
    }

}
