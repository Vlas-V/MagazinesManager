using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public class Person
    {
        private string name;
        private string surname;
        private DateTime birthdate;

        public Person(string name = "", string surname = "", DateTime birthdate = new DateTime())
        {
            Name = name;
            Surname = surname;
            Birthdate = birthdate; 
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
        public static bool operator ==(Person p1, Person p2) => p1.Equals(p1);
        public static bool operator !=(Person p1, Person p2) => !p1.Equals(p1);

    }
}