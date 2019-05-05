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
        public double Rating { get; set; }

        double IRateAndCopy.Rating => throw new NotImplementedException();

        public Article(Person author = null, string name = "", double rating = 0)
        {
            Author = author ?? new Person();
            Name = name;
            Rating = rating;
        }

        public override string ToString()
        {
            string info = "";
            info += "Author:          " + Author.ToShortString() + "\n";
            info += "Article's name:  " + Name + "\n";
            info += "Rating:          " + Rating;
            return info;
        }

        object IRateAndCopy.DeepCopy()
        {
            throw new NotImplementedException();
        }
    }
}