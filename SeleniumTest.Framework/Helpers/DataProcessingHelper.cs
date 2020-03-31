using Newtonsoft.Json;
using SeleniumTest.Framework.Data;
using System.Collections.Generic;
using System.IO;

namespace SeleniumTest.Framework.Helpers
{
    public static class DataProcessingHelper
    {
        private static readonly string _pathToBin = Path.GetDirectoryName(typeof(InputData).Assembly.Location);
        private const string PathToInputData = "Data\\InputData.json";
        private const string PathToConfig = "Data\\Config.json";


        public static IList<InputData> GetTestData()
        {
            var path = Path.Combine(_pathToBin, PathToInputData);
            using var file = File.OpenText(path);
            JsonSerializer serializer = new JsonSerializer();
            var testData = (IList<InputData>)serializer.Deserialize(file, typeof(IList<InputData>));
            return testData;
        }

        public static ConfigData GetConfigData()
        {
            var path = Path.Combine(_pathToBin, PathToConfig);
            using var file = File.OpenText(path);
            JsonSerializer serializer = new JsonSerializer();
            var configData = (ConfigData)serializer.Deserialize(file, typeof(ConfigData));
            return configData;
        }
    }
}