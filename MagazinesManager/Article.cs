using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public class Article : IRateAndCopy
    {
        public Person Author { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }

        public double Rating => Rate;

        public Article(Person author = null, string name = "", double rating = 0)
        {
            Author = author ?? new Person();
            Name = name;
            Rate = rating;
        }

        public override string ToString()
        {
            string info = "";
            info += "Author:          " + Author.ToShortString() + "\n";
            info += "Article's name:  " + Name + "\n";
            info += "Rate:          " + Rate;
            return info;
        }

        public object DeepCopy()
        {
            return new Article (this.Author, this.Name, this.Rate);
        }
    }
}