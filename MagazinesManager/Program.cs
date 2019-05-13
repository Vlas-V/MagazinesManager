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

            // 1
            Console.WriteLine("Block 1");

            Edition e1 = new Edition("Alfa", new DateTime(2001, 12, 12), 6000);
            Edition e2 = new Edition("Alfa", new DateTime(2001, 12, 12), 6000);

            Console.WriteLine($"Reference Equality: {ReferenceEquals(e1, e2)}");
            Console.WriteLine($"Value Equality: {e1 == e2}");
            Console.WriteLine($"Hash Code of e1: {e1.GetHashCode()}");
            Console.WriteLine($"Hash Code of e2: {e2.GetHashCode()}");

            Console.WriteLine();



            // 2
            Console.WriteLine("Block 2");

            try
            {
                e1.Circulation = -2000;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("\n*** Error! ***");
                Console.WriteLine("Member name: {0}", e.TargetSite);
                Console.WriteLine("Class defining member: {0}",
                e.TargetSite.DeclaringType);
                Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source: {0}", e.Source);
            }
            Console.WriteLine();


            // 3
            Console.WriteLine("Block 3");

            Person author1 = new Person("Jon", "Snow", new DateTime(1999, 12, 1));
            Person author2 = new Person("Joseph", "Avelsev", new DateTime(1999, 12, 1));
            Person author3 = new Person("Jo", "Jonson", new DateTime(1999, 12, 1));
            Person author4 = new Person("Bruce", "Ali", new DateTime(1999, 12, 1));
            Person author5 = new Person("Donald", "Trump", new DateTime(1999, 12, 1));


            Article article1 = new Article(author1, "Winter", 88);
            Article article2 = new Article(author2, "House", 89);
            Article article3 = new Article(author3, "Summer", 34);
            Article article4 = new Article(author4, "Ukraine Current Political Situation", 90);


            Magazine magazine1 = new Magazine();
            magazine1.Edition = e1;
            magazine1.Frequency = Frequency.Monthly;

            magazine1.AddEditors(author1, author2, author3);
            magazine1.AddArticles(article1);
            Console.WriteLine(magazine1.ToString());

            magazine1.AddEditors(author4, author5);
            magazine1.AddArticles(article2, article3, article4);
            Console.WriteLine(magazine1.ToString());
            Console.WriteLine();


            // 4
            Console.WriteLine("Block 4");

            Edition edition1 = new Edition();
            edition1 = magazine1.Edition;

            Console.WriteLine(edition1.ToString());
            Console.WriteLine();
            Console.WriteLine();


            // 5
            Console.WriteLine("Block 5");

            Magazine magazine1Copy = new Magazine();
            magazine1Copy = (Magazine)magazine1.DeepCopy();


            Console.WriteLine("Before changes");
            Console.WriteLine("Original:\n");
            Console.WriteLine(magazine1.ToString());
            Console.WriteLine("Copy:\n");
            Console.WriteLine(magazine1Copy.ToString());
            Console.WriteLine();

            Console.WriteLine("Inner object:\n");
            Console.WriteLine("Original:\n");
            Console.WriteLine((magazine1.Articles)[0].ToString());
            Console.WriteLine();
            Console.WriteLine("Copy:\n");
            Console.WriteLine((magazine1Copy.Articles)[0].ToString());

            // Changes
            article1.Name = "Changed Name";

            magazine1.EditionName = "Changed Name Again";
            magazine1.AddArticles(new Article(author5, "Village Life", 89));
            magazine1.Editors = new List<Person> { author5 };

            Console.WriteLine("After changes");
            Console.WriteLine("Original:\n");
            Console.WriteLine(magazine1.ToString());
            Console.WriteLine("Copy:\n");
            Console.WriteLine(magazine1Copy.ToString());
            Console.WriteLine();

            Console.WriteLine("Inner object:\n");
            Console.WriteLine("Original:\n");
            Console.WriteLine((magazine1.Articles)[0].ToString());
            Console.WriteLine();
            Console.WriteLine("Copy:\n");
            Console.WriteLine((magazine1Copy.Articles)[0].ToString());



            // 6
            Console.WriteLine("Block 6");


            Console.WriteLine(magazine1.ToString());

            Console.WriteLine("Higher than:");
            foreach (Article a in magazine1.ArticlesHigher(80))
            {
                Console.WriteLine(a.ToString());
            }

            Console.WriteLine("With a provided word word:");
            foreach (Article a in magazine1.ArticlesWith("Situation"))
            {
                Console.WriteLine(a.ToString());
            }

        }
    }
}

