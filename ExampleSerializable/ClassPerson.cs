// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace ExampleSerializable
{
    [Serializable]
    internal class ClassPerson
    {
        public ClassPerson(string name, string surname, DateTime birthDay, string description)
        {
            Name = name;
            Surname = surname;
            BirthDay = birthDay;
            Description = description;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        
        public DateTime _birthDay;
        public DateTime BirthDay
        {
            get => new DateTime(_birthDay.Year, _birthDay.Month, _birthDay.Day);
            set => _birthDay = value;
        }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"{BirthDay.Year}-{BirthDay.Month}-{BirthDay.Day}. {Name} {Surname}. {Description}.";
        }
    }
}
