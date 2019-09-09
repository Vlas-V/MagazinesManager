using System;
using System.Linq;


namespace MagazinesManager
{
    public partial class Article : IRateAndCopy
    {
        public Person Author { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }

        public double Rating => Rate;

        public Article(Person author = null, string name = "", double rating = 0, Boolean random = false)
        {
            if (random)
            {
                Author = author ?? new Person(random: true); // ? (every article is gonna has a unique author?)
                Name = randomNames[r.Next(randomNames.Count())];
                Rate = r.NextDouble() * 10;

                // * Check the other part of the class (Article.Randomization)
            }
            else
            {
                Author = author ?? new Person();
                Name = name;
                Rate = rating;
            }
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
            return new Article (new Person(Author.Name, Author.Surname, Author.Birthdate), this.Name, this.Rate);
        }
    }
}