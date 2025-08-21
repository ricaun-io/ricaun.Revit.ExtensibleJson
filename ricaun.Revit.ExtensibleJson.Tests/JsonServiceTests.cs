using Autodesk.Revit.DB;
using NUnit.Framework;
using System;

namespace ricaun.Revit.ExtensibleJson.Tests
{
    public class JsonServiceTests
    {
        class Model
        {
            public ElementId Id { get; set; }
            public string Text { get; set; }
            public XYZ Point { get; set; }
        }

        [Test]
        public void TestModel()
        {
            var model = new Model()
            {
                Id = new ElementId(BuiltInCategory.OST_GenericModel),
                Text = "Hello Revit",
                Point = new XYZ(12, 1, -100)
            };

            var result = TestJsonService(model);
            Assert.IsTrue(result, "ElementId serialization failed.");
        }

        [Test]
        public void TestModel_Null()
        {
            var model = new Model()
            {
                Id = null,
                Text = "Hello Revit Null",
                Point = null
            };

            var result = TestJsonService(model);
            Assert.IsTrue(result, "ElementId serialization failed.");
        }

        public bool TestJsonService<T>(T value)
        {
            var jsonService = new JsonService<T>();
            var json = jsonService.Serialize(value);
            var jsonDeserialize = jsonService.Deserialize(json);
            var jsonSerialize = jsonService.Serialize(jsonDeserialize);
            var result = json == jsonSerialize;
            Console.WriteLine($"{result} \t{json} \t{jsonSerialize}");
            return result;
        }
    }
}
