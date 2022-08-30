# ricaun.Revit.ExtensibleJson

ricaun.Revit.ExtensibleJson is a package for Revit to use Newtonsoft.Json as Extension with JsonService.

[![Revit 2017](https://img.shields.io/badge/Revit-2017+-blue.svg)](../..)
[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Publish](../../actions/workflows/Publish.yml/badge.svg)](../../actions)
[![Develop](../../actions/workflows/Develop.yml/badge.svg)](../../actions)
[![Release](https://img.shields.io/nuget/v/ricaun.Revit.ExtensibleJson?logo=nuget&label=release&color=blue)](https://www.nuget.org/packages/ricaun.Revit.ExtensibleJson)

## Release

* [Latest release](../../releases/latest)

## JsonService<TJson> / JsonService 

```C#
IJsonService<TJson> jsonService = new JsonService<TJson>();
```
### Serialize / SerializeObject
```C#
TJson value;
string serialize = jsonService.Serialize(value);
```
```C#
object value;
string serialize = jsonService.SerializeObject<object>(value);
```

### Deserialize / DeserializeObject
```C#
string value;
TJson deserialize = jsonService.Deserialize(value);
```
```C#
string value;
object deserialize = jsonService.DeserializeObject<object>(value);
```

### JsonSerializerSettings
```C#
JsonSerializerSettings setting = jsonService.GetSettings();
```

### V�deo

[![VideoIma]][Video]

## License

This Project is [licensed](LICENSE) under the [MIT Licence](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this package? Please [star this project on GitHub](../../stargazers)!

[Video]: https://youtu.be/yvyXABcAvtc
[VideoIma]: https://img.youtube.com/vi/yvyXABcAvtc/hqdefault.jpg