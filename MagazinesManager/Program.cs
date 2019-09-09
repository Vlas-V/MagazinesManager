using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Random names for Persons test 


            int people_count = 20;
            Person[] people = new Person[people_count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(random: true); 
            }

            foreach (Person p in people)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine();
            }



            // Delegates and Events Testin

            // 1
            Person author1 = new Person("Jon", "Snow", new DateTime(1999, 12, 1));
            Person author2 = new Person("Joseph", "Avelsev", new DateTime(1999, 12, 1));
            Person author3 = new Person("Jo", "Jonson", new DateTime(1999, 12, 1));
            Person author4 = new Person("Bruce", "Ali", new DateTime(1999, 12, 1));
            Person author5 = new Person("Donald", "Trump", new DateTime(1999, 12, 1));
            Person author6 = new Person("Bill", "Clinton", new DateTime(1999, 12, 1));
            Person author7 = new Person("Bill", "Gates", new DateTime(1999, 12, 1));

            Article article1 = new Article(author1, "Winter", 88);
            Article article2 = new Article(author2, "House", 89);
            Article article3 = new Article(author3, "Summer", 34);
            Article article4 = new Article(author4, "Ukrainian Current Political Situation", 90);
            Article article5 = new Article(author4, "Done?", 90);
            Article article6 = new Article(author7, "The first real action", 90);
            Article article7 = new Article(author6, "Stop complaining", 90);
            Article article8 = new Article(author5, "Oh, I love this planet!", 90);

            Magazine magazine1 = new Magazine("AARP", new DateTime(1943, 12, 1), 6000, Frequency.Weekly);
            magazine1.AddEditors(author1, author2);
            magazine1.AddArticles(article1, article2, article3);

            Magazine magazine2 = new Magazine("National Geotraphic", new DateTime(1973, 05, 12), 14000, Frequency.Monthly);
            magazine2.AddEditors(author3, author4);
            magazine2.AddArticles(article2, article3, article4);

            Magazine magazine3 = new Magazine("Time Magazine", new DateTime(1960, 01, 20), 8000, Frequency.Monthly);
            magazine3.AddEditors(author5, author6);
            magazine3.AddArticles(article4, article5, article6);

            Magazine magazine4 = new Magazine("American First", new DateTime(1900, 03, 22), 10000, Frequency.Monthly);
            magazine4.AddEditors(author7, author4);
            magazine4.AddArticles(article7, article6, article8);





            MagazineCollection magazineCollection = new MagazineCollection();
            magazineCollection.AddMagazines(magazine1, magazine2, magazine3, magazine4);

            Console.WriteLine(magazineCollection.ToString());




        }
    }
}

