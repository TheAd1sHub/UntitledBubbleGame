using Newtonsoft.Json;

namespace Assets.MBG.Develop.CommonServices.SaveHandling
{
    public static class JSONSerializer
    {
        private static JsonSerializerSettings FormatterSettings => new JsonSerializerSettings()
        {
            Culture = System.Globalization.CultureInfo.InvariantCulture,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
        };

        public static string Serialize<T>(T @object)
            => JsonConvert.SerializeObject(@object, FormatterSettings);

        public static T Deserialize<T>(string json)
            => JsonConvert.DeserializeObject<T>(json, FormatterSettings);
    }
}
