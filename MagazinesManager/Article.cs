using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public class Article
    {
        public Person Author { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }


        public Article(Person author = null, string name = "", double rate = 0)
        {
            Author = author ?? new Person();
            Name = name;
            Rate = rate;
        }

        public override string ToString()
        {
            string info = "";
            info += "Author:          " + Author.ToShortString() + "\n";
            info += "Article's name:  " + Name + "\n";
            info += "Rating:          " + Rate;
            return info;
        }
    }
}