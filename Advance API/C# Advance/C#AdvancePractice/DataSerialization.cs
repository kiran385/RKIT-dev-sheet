using System.Xml.Serialization;
using System.Text.Json;
using System.IO;

namespace CsharpAdvancePractice
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class DataSerialization
    {
        public static void DataSerializationDemo()
        {
            Person person = new Person();
            person.Name = "Kiran";
            person.Age = 20;

            string jsonString = JsonSerializer.Serialize(person);
            Console.WriteLine("JSON Serialization: "+ jsonString);

            Person jsonContent = JsonSerializer.Deserialize<Person>(jsonString);
            Console.WriteLine("JSON Deserialization: "+jsonContent);

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
