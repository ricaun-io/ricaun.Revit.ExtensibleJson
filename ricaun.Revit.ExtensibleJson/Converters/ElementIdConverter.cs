using Autodesk.Revit.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace ricaun.Revit.ExtensibleJson.Converters
{
    /// <summary>
    /// Provides a JSON converter for <see cref="Autodesk.Revit.DB.ElementId"/> objects, enabling serialization and deserialization
    /// between <see cref="Autodesk.Revit.DB.ElementId"/> and <see cref="JObject"/> representations.
    /// </summary>
    public class ElementIdConverter : ObjectJsonConverter<ElementId>
    {
        /// <summary>
        /// The key used to store the integer value of the <see cref="Autodesk.Revit.DB.ElementId"/> in JSON.
        /// </summary>
        private const string ElementIdKeyInteger = "IntegerValue";

        /// <summary>
        /// The key used to store the value of the <see cref="Autodesk.Revit.DB.ElementId"/> in JSON.
        /// </summary>
        private const string ElementIdKey = "Value";

        /// <summary>
        /// Creates a new <see cref="Autodesk.Revit.DB.ElementId"/> instance from the specified identifier.
        /// </summary>
        /// <param name="id">The identifier value.</param>
        /// <returns>
        /// A new <see cref="Autodesk.Revit.DB.ElementId"/> instance, or <c>null</c> if no suitable constructor is found.
        /// </returns>
        private static ElementId NewElementId(long id)
        {
            if (_constructor is not null)
                return _constructor.Invoke(new object[] { Convert.ChangeType(id, _constructorType) }) as ElementId;

            var type = typeof(ElementId);
            foreach (var constructorType in new[] { typeof(long), typeof(int) })
            {
                _constructor = type.GetConstructor(new[] { constructorType });
                _constructorType = constructorType;
                if (_constructor is not null)
                {
                    return NewElementId(id);
                }
            }
            return null;
        }

        /// <summary>
        /// Stores the constructor info for <see cref="Autodesk.Revit.DB.ElementId"/> to optimize repeated instantiation.
        /// </summary>
        private static ConstructorInfo _constructor;

        /// <summary>
        /// Stores the type of the constructor parameter for <see cref="Autodesk.Revit.DB.ElementId"/>.
        /// </summary>
        private static Type _constructorType;

        /// <summary>
        /// Gets the value of the specified <see cref="Autodesk.Revit.DB.ElementId"/> instance.
        /// </summary>
        /// <param name="elementId">The <see cref="Autodesk.Revit.DB.ElementId"/> instance.</param>
        /// <returns>
        /// The value of the <see cref="Autodesk.Revit.DB.ElementId"/>, or 0 if not found.
        /// </returns>
        private static long GetValue(ElementId elementId)
        {
            if (_property is not null)
                return (long)Convert.ChangeType(_property.GetValue(elementId), typeof(long));

            var type = typeof(ElementId);
            foreach (var name in new[] { ElementIdKey, ElementIdKeyInteger })
            {
                _property = type.GetProperty(name);
                if (_property is not null)
                {
                    return GetValue(elementId);
                }
            }
            return 0;
        }

        /// <summary>
        /// Stores the property info for the value of <see cref="Autodesk.Revit.DB.ElementId"/> to optimize repeated access.
        /// </summary>
        private static PropertyInfo _property;

        /// <summary>
        /// Reads a <see cref="JObject"/> and converts it to an <see cref="Autodesk.Revit.DB.ElementId"/> instance.
        /// </summary>
        /// <param name="value">The <see cref="JObject"/> containing the element ID value.</param>
        /// <returns>
        /// An <see cref="Autodesk.Revit.DB.ElementId"/> instance, or <c>null</c> if the value is not present.
        /// </returns>
        public override ElementId Read(JObject value)
        {
            var id = value?.Value<long?>(ElementIdKey) ?? value?.Value<long?>(ElementIdKeyInteger);
            if (id == null) return null;
            return NewElementId((long)id);
        }

        /// <summary>
        /// Converts an <see cref="Autodesk.Revit.DB.ElementId"/> instance to a <see cref="JObject"/> for JSON serialization.
        /// </summary>
        /// <param name="value">The <see cref="Autodesk.Revit.DB.ElementId"/> to serialize.</param>
        /// <returns>
        /// A <see cref="JObject"/> representing the <see cref="Autodesk.Revit.DB.ElementId"/>.
        /// </returns>
        public override object Write(ElementId value)
        {
            var jObject = new JObject();
            jObject[ElementIdKey] = GetValue(value);
            return jObject;
        }
    }
}
