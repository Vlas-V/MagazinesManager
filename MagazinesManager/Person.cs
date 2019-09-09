using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public partial class Person
    {
        private string name;
        private string surname;
        private DateTime birthdate;

        public Person(string name = "", string surname = "", DateTime birthdate = new DateTime(), Boolean random = false)
        {
            // Generate random values for the fields
            if (random)
            {
                Name = randomNames[r.Next(randomNames.Count())];
                Surname = randomSurnames[r.Next(randomSurnames.Count())];
                Birthdate = new DateTime(1930 + r.Next(72), r.Next(1, 13), r.Next(1, 28));
            }
            else
            {
                Name = name;
                Surname = surname;
                Birthdate = birthdate;
            }

        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
            }
        }

        public DateTime Birthdate
        {
            get => birthdate;
            set
            {
                birthdate = value;
            }
        }

        public int Year
        {
            get => birthdate.Year;
            set
            {
                birthdate = new DateTime(value, birthdate.Month, birthdate.Day);
            }
        }

        public override string ToString()
        {
            string info = "";
            info += "Name:      " + Name + "\n";
            info += "Surname:   " + Surname + "\n";
            info += "Birthdate: " + Birthdate;
            return info;
        }

        public string ToShortString()
        {
            return Name + " " + Surname;
        }

        public override int GetHashCode() => this.ToString().GetHashCode();
        public override bool Equals(object obj) => obj?.ToString() == this.ToString();
        public static bool operator ==(Person p1, Person p2) => p1.Equals(p2);
        public static bool operator !=(Person p1, Person p2) => !p1.Equals(p2);
        public virtual object DeepCopy()
        {
            return new Person(this.name, this.surname, this.birthdate);
        }


    }
}