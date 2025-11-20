using System.Xml.Serialization;
using System.Text.Json;

namespace CsharpAdvancePractice
{
    /// <summary>
    /// Class for Person
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// Class containing data serialization demo
    /// </summary>
    internal class DataSerialization
    {
        /// <summary>
        /// Method containing data serialization demo
        /// </summary>
        public static void DataSerializationDemo()
        {
            Person person = new Person();
            person.Name = "Kiran";
            person.Age = 20;

            string jsonString = JsonSerializer.Serialize(person);
            Console.WriteLine("JSON Serialization: "+ jsonString);

            Person jsonContent = JsonSerializer.Deserialize<Person>(jsonString);
            Console.WriteLine("\nJSON Deserialization: "+jsonContent);


            // Serialization of List of object
            List<Person> list = new List<Person>
            {
                new Person{Name = "Ajay", Age = 21},
                new Person{Name = "Jay", Age = 22}
            };

            string jsonStringList = JsonSerializer.Serialize(list, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            Console.WriteLine("\nJSON Serialization of object list: " + jsonStringList);

            List<Person> jsonContentList = JsonSerializer.Deserialize<List<Person>>(jsonStringList);
            Console.WriteLine("\nJSON Deserialization of object list: " + string.Join('|', jsonContentList));


            // XML serialization
            string fileName = "person.xml";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using StreamWriter writer = new StreamWriter(fileName);
            xmlSerializer.Serialize(writer,person);
            writer.Close();
            Console.WriteLine("\nXML Serialization\n" +File.ReadAllText(fileName));

            using StreamReader reader = new StreamReader(fileName);
            Console.WriteLine("\nXML Deserialization\n" +xmlSerializer.Deserialize(reader));
        }
    }
}
