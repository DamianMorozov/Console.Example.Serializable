// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExampleSerializable
{
    internal class Program
    {
        internal static void Main()
        {
            Console.WriteLine("Example of Serializable.");

            var person1 = new ClassPerson("Tom", "Sawyer", new DateTime(1876, 12, 30), "Mark Twain novel");
            Console.WriteLine("Person: " + person1);
            var person2 = new ClassPerson("Huckleberry", "Finn", new DateTime(1884, 10, 20), "Mark Twain novel");
            Console.WriteLine("Person: " + person2);
            var people = new[] { person1, person2 };

            var formatter = new BinaryFormatter();
            Console.WriteLine("Data serialize start.");
            using (var fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
            }
            Console.WriteLine("Data serialize complete.");

            Console.WriteLine("Data deserialized start.");
            using (var fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                people = (ClassPerson[]) formatter.Deserialize(fs);
                foreach (var item in people)
                {
                    Console.WriteLine($"Person: {item}");
                }
            }
            Console.WriteLine("Data deserialized complete.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
