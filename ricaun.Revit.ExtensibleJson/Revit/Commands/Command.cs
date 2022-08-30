using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
#if DEBUG
namespace ricaun.Revit.ExtensibleJson.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            var model = new Model()
            {
                Id = new ElementId(BuiltInCategory.OST_GenericModel),
                Text = "Hello Revit",
                Point = new XYZ(12, 1, -100)
            };

            TestJsonService(model);

            return Result.Succeeded;
        }

        public bool TestJsonService<T>(T value)
        {
            var jsonService = new JsonService<T>();
            var json = jsonService.Serialize(value);
            var jsonDeserialize = jsonService.Deserialize(json);
            var jsonSerialize = jsonService.Serialize(jsonDeserialize);
            var result = json == jsonSerialize;
            Console.WriteLine($"{result} \t{json} \t{jsonSerialize}");
            //Console.WriteLine(json);
            //Console.WriteLine(jsonSerialize);
            return result;
        }

    }

    public class Model
    {
        public ElementId Id { get; set; }
        public string Text { get; set; }
        public XYZ Point { get; set; }
    }
}
#endif