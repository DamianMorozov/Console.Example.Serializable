// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace ExampleSerializable
{
    internal class Program
    {
        internal static void Main()
        {
            var numberMenu = -1;
            while (numberMenu != 0)
            {
                PrintCaption();
                try
                {
                    numberMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    numberMenu = -1;
                }
                Console.WriteLine();
                PrintSwitch(numberMenu);
            }
        }

        private static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                     Examples of serializable                   ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine("0. Exit from console.");
            Console.WriteLine("1. BinaryFormatter.");
            Console.WriteLine("2. SoapFormatter.");
            Console.WriteLine("3. XmlSerializer (not worked).");
            Console.WriteLine("4. DataContractJsonSerializer (not worked).");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.Write("Type switch: ");
        }

        private static void PrintSwitch(int numberMenu)
        {
            Console.Clear();
            var isPrintMenu = false;
            switch (numberMenu)
            {
                case 1:
                    isPrintMenu = true;
                    SerializableBinaryFormatter();
                    break;
                case 2:
                    isPrintMenu = true;
                    SerializableSoapFormatter();
                    break;
                case 3:
                    isPrintMenu = false;
                    SerializableXmlSerializer();
                    break;
                case 4:
                    isPrintMenu = false;
                    SerializableDataContractJsonSerializer();
                    break;
            }
            if (isPrintMenu)
            {
                Console.WriteLine(@"----------------------------------------------------------------------");
                Console.Write("Type any key to return in main menu.");
                Console.ReadKey();
            }
        }

        private static void SerializableBinaryFormatter()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                       BinaryFormatter                          ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine();

            var person1 = new ClassPerson("Tom", "Sawyer", new DateTime(1876, 12, 30), "Mark Twain novel");
            Console.WriteLine("Person: " + person1);
            var person2 = new ClassPerson("Huckleberry", "Finn", new DateTime(1884, 10, 20), "Mark Twain novel");
            Console.WriteLine("Person: " + person2);
            var people = new[] { person1, person2 };
            Console.WriteLine("var people = new[] { person1, person2 };");
            Console.WriteLine();

            var formatter = new BinaryFormatter();
            Console.WriteLine("var formatter = new BinaryFormatter();");
            using (var fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("using (var fs = new FileStream(\"people.dat\", FileMode.OpenOrCreate))");
                formatter.Serialize(fs, people);
                Console.WriteLine("formatter.Serialize(fs, people);");
            }
            Console.WriteLine();

            using (var fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("using (var fs = new FileStream(\"people.dat\", FileMode.OpenOrCreate))");
                people = (ClassPerson[])formatter.Deserialize(fs);
                Console.WriteLine("people = (ClassPerson[])formatter.Deserialize(fs);");
                foreach (var item in people)
                {
                    Console.WriteLine($"Person: {item}");
                }
            }
        }

        private static void SerializableSoapFormatter()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                        SoapFormatter                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine();

            var addresses = new Hashtable();
            addresses.Add("Jeff", "123 Main Street, Redmond, WA 98052");
            addresses.Add("Fred", "987 Pine Road, Phila., PA 19116");
            addresses.Add("Mary", "PO Box 112233, Palo Alto, CA 94301");

            using (var fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("using (var fs = new FileStream(\"people.dat\", FileMode.OpenOrCreate))");
                var formatter = new SoapFormatter();
            }
        }

        private static void SerializableXmlSerializer()
        {
            
        }

        private static void SerializableDataContractJsonSerializer()
        {
            
        }
    }
}
