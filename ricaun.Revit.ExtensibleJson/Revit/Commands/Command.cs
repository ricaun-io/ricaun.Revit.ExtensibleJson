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

            var model = new Model() { Id = new ElementId(BuiltInCategory.OST_GenericModel), Text = "Hello Revit" };
            var jsonServiceModel = new JsonService<Model>();

            var o = jsonServiceModel.DeserializeObject<object>("{}");
            Console.WriteLine(o.GetType());
            Console.WriteLine(jsonServiceModel.SerializeObject(o));

            var serialize = jsonServiceModel.Serialize(model);
            var modelDeserialize = jsonServiceModel.Deserialize(serialize);

            Console.WriteLine(modelDeserialize);
            Console.WriteLine(modelDeserialize.Id == new ElementId(BuiltInCategory.OST_GenericModel));

            var jsonService = new JsonService();

            var smodel = jsonService.SerializeObject(model);



            Console.WriteLine(jsonService.DeserializeObject<Model>(smodel));

            return Result.Succeeded;
        }
    }

    public class Model
    {
        public ElementId Id { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{Id} {Text}";
        }
    }
}
#endif