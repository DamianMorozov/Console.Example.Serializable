// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.IO;
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
                    SerializableXmlSerializer();
                    break;
                case 4:
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

            SerializableBinaryFormatterSerialize();
            Console.WriteLine(@"----------------------------------------------------------------------");

            SerializableBinaryFormatterDeserialize();
        }

        private static void SerializableBinaryFormatterSerialize()
        {
            Console.WriteLine("Serialize.");

            var persons = GetPersons();
            Console.WriteLine("var persons = GetPersons();");

            var formatter = new BinaryFormatter();
            Console.WriteLine("var formatter = new BinaryFormatter();");
            using (var fs = new FileStream("persons.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("using (var fs = new FileStream(\"persons.dat\", FileMode.OpenOrCreate))");
                try
                {
                    formatter.Serialize(fs, persons);
                    Console.WriteLine("formatter.Serialize(fs, people);");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                }
            }
        }

        private static void SerializableBinaryFormatterDeserialize()
        {
            Console.WriteLine("Deserialize.");

            var formatter = new BinaryFormatter();
            Console.WriteLine("var formatter = new BinaryFormatter();");
            using (var fs = new FileStream("persons.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("using (var fs = new FileStream(\"persons.dat\", FileMode.OpenOrCreate))");
                try
                {
                    var persons = (ClassPerson[])formatter.Deserialize(fs);
                    Console.WriteLine("people = (ClassPerson[])formatter.Deserialize(fs);");
                    foreach (var item in persons)
                    {
                        Console.WriteLine($"Person: {item}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                }
            }
        }

        private static void SerializableSoapFormatter()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                        SoapFormatter                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            SerializableSoapFormatterSerialize();
            Console.WriteLine(@"----------------------------------------------------------------------");

            SerializableSoapFormatterDeserialize();
        }

        private static void SerializableSoapFormatterSerialize()
        {
            Console.WriteLine("Serialize.");

            var addresses = GetAddresses();
            Console.WriteLine("var addresses = GetAddresses();");

            var formatter = new SoapFormatter();
            Console.WriteLine("var formatter = new SoapFormatter();");
            using (var fs = new FileStream("addresses.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("using (var fs = new FileStream(\"addresses.dat\", FileMode.OpenOrCreate))");
                try
                {
                    formatter.Serialize(fs, addresses);
                    Console.WriteLine("formatter.Serialize(fs, addresses);");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                }
            }
        }

        private static void SerializableSoapFormatterDeserialize()
        {
            Console.WriteLine("Deserialize.");

            var formatter = new SoapFormatter();
            Console.WriteLine("var formatter = new SoapFormatter();");
            using (var fs = new FileStream("addresses.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("using (var fs = new FileStream(\"addresses.dat\", FileMode.OpenOrCreate))");
                try
                {
                    var addresses = (Hashtable)formatter.Deserialize(fs);
                    Console.WriteLine("people = (Hashtable)formatter.Deserialize(fs);");
                    foreach (var item in addresses.Keys)
                    {
                        Console.WriteLine($"Address: {item}. {addresses[item]}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                }
            }
        }

        private static void SerializableXmlSerializer()
        {

        }

        private static void SerializableDataContractJsonSerializer()
        {

        }

        private static Hashtable GetAddresses()
        {
            return new Hashtable
            {
                { "Jeff", "123 Main Street, Redmond, WA 98052" },
                { "Fred", "987 Pine Road, Phila., PA 19116" },
                { "Mary", "PO Box 112233, Palo Alto, CA 94301" },
            };
        }

        private static ClassPerson[] GetPersons()
        {
            return new[]
            {
                new ClassPerson("Tom", "Sawyer", new DateTime(1876, 12, 30), "Mark Twain novel"),
                new ClassPerson("Huckleberry", "Finn", new DateTime(1884, 10, 20), "Mark Twain novel"),
            };
        }
    }

}
