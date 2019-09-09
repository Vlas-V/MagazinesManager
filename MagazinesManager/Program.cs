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

            // This can be called a generation of related MagazineCollections
            // with random-state objects 


            int authors_number = 20;
            int articles_number = 100;
            int magazines_number = 10;


            // Generate random authors 
            Person[] authors = new Person[authors_number];

            for (int i = 0; i < authors.Length; i++)
            {
                authors[i] = new Person(random: true); 
            }


            // Generate random articles (with default random authors)
            Random r = new Random();

            Article[] articles = new Article[articles_number];

            for (int i = 0; i < articles.Length; i++)
            {
                articles[i] = new Article(author: authors[r.Next(authors.Length)], random: true);
            }


            // Generate magazines with articles and editors 
            Magazine[] magazines = new Magazine[magazines_number];

            int articlesEach = articles_number / magazines_number;
            int editorsEach = authors_number / magazines_number;

            for (int i = 0; i < magazines_number; i++)
            {
                magazines[i] = new Magazine(random: true);
                for (int j = 0; j < articlesEach; j++) magazines[i].AddArticles(articles[i * articlesEach + j]);
                for (int j = 0; j < editorsEach; j++) magazines[i].AddEditors(authors[i * editorsEach + j]);
            }


            // Generate magazines
            MagazineCollection magazineCollection1 = new MagazineCollection("THE FIRST coll.");
            MagazineCollection magazineCollection2 = new MagazineCollection("THE SECOND coll.");

            for (int i = 0; i < magazines.Length; i++)
            {
                if (i < 6)
                {
                    magazineCollection1.AddMagazines(magazines[i]);
                }
                else
                {
                    magazineCollection2.AddMagazines(magazines[i]);
                }
            }

            Console.WriteLine(magazineCollection1.ToString());
            Console.WriteLine(magazineCollection2.ToString());



            Console.WriteLine();



        }
    }
}

