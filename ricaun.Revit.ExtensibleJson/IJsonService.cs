using Newtonsoft.Json;

namespace ricaun.Revit.ExtensibleJson
{
    /// <summary>
    /// IJsonService
    /// </summary>
    public interface IJsonService : IJsonService<object>
    {

    }

    /// <summary>
    /// IJsonService
    /// </summary>
    /// <typeparam name="TJson"></typeparam>
    public interface IJsonService<TJson>
    {
        /// <summary>
        /// GetSettings
        /// </summary>
        /// <returns></returns>
        JsonSerializerSettings GetSettings();

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string Serialize(TJson value);

        /// <summary>
        /// SerializeObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        string SerializeObject<T>(T value);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        TJson Deserialize(string value);

        /// <summary>
        /// DeserializeObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        T DeserializeObject<T>(string value);
    }
}