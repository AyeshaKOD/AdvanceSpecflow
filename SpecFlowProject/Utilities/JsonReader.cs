using Newtonsoft.Json;
using SpecFlowProject.JsonObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpecFlowProject.Utilities
{
    public class JsonReader
    {


        //public static List<T> ReadTestDataFromJson<T>(string jsonFilePath)
        //{
        //    try
        //    {
        //        string jsonContent = File.ReadAllText(jsonFilePath);
        //        List<T> testData = JsonConvert.DeserializeObject<List<T>>(jsonContent);
        //        return testData;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions appropriately (e.g., log the error)
        //        Console.WriteLine($"Error reading JSON file: {ex.Message}");
        //        return null;
        //    }
        public static List<T> LoadData<T>(string path)
        {
            using StreamReader reader = new StreamReader(path);
            var jsonContent = reader.ReadToEnd();
            List<T> objectList = JsonConvert.DeserializeObject<List<T>>(jsonContent);
            return objectList;
        }

    }

}

