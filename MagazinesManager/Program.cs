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

            // Generate two related magazines collections with random state

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


            // Create two listeners 
            Listener listenerAddedReplacedFROMFirst = new Listener();
            Listener listenerAddedFROMFirstSecond = new Listener();

            // Subscibe the listeners
            
            // Subscibe the first listener to the Added and Replaced events of the first collections
            MagazineCollection.MagazineListHandler d = new MagazineCollection.MagazineListHandler(listenerAddedReplacedFROMFirst.MagazineAddedEventListenerSubscriber);
            magazineCollection1.MagazineAdded += d;
            magazineCollection1.MagazineReplaced += new MagazineCollection.MagazineListHandler(listenerAddedReplacedFROMFirst.MagazineReplacedEventListenerSubscriber);

            // Subscibe the second listener to the Added events of the both colletions
            magazineCollection1.MagazineAdded += listenerAddedFROMFirstSecond.MagazineAddedEventListenerSubscriber;
            magazineCollection2.MagazineAdded += listenerAddedFROMFirstSecond.MagazineAddedEventListenerSubscriber;


            // State of the both magazines collections before changes 
            Console.WriteLine("******************************************************");
            Console.WriteLine("State of the both magazines collections before changes");
            Console.WriteLine("******************************************************");
            Console.WriteLine(magazineCollection1.ToString());
            Console.WriteLine(magazineCollection2.ToString());

            // CHANGES IN THE COLLECTION THAT WILL TRIGGER THE EVENTS

            Console.WriteLine("******************************************************");
            Console.WriteLine("Addition and replacement elements");
            Console.WriteLine("******************************************************");

            // Add an element to the first colletion [works]
            Magazine mAddTest1 = new Magazine(random: true);
            Console.WriteLine("Magazine for the AddTest 1 (adding to the first collection):");
            Console.WriteLine(mAddTest1);
            magazineCollection1.AddMagazines(mAddTest1);

            // Add an element to the second colletion 
            Magazine mAddTest2 = new Magazine(random: true);
            Console.WriteLine("Magazine for the AddTest 2 (adding to the second collection):");
            Console.WriteLine(mAddTest2);
            magazineCollection2.AddMagazines(mAddTest2);

            // Replace with Replace()
            Magazine mReplaceTest1 = new Magazine(random: true);
            Console.WriteLine("Magazine for the Replace() test 1 (replace the first elements in the both collections)");
            Console.WriteLine(mReplaceTest1);
            magazineCollection1.Replace(0, mReplaceTest1);
            magazineCollection2.Replace(0, mReplaceTest1);

            // Replace with[]
            Magazine mReplaceTest2 = new Magazine(random: true);
            Console.WriteLine("Magazine for the Replace() test 2 (replace the third elements in the both collections)");
            Console.WriteLine(mReplaceTest2);
            magazineCollection1[2] = mReplaceTest2;
            magazineCollection2[2] = mReplaceTest2;




            // State of the both magazines collections after changes 
            Console.WriteLine("******************************************************");
            Console.WriteLine("State of the both magazines collections after changes");
            Console.WriteLine("******************************************************");
            Console.WriteLine(magazineCollection1.ToString());
            Console.WriteLine(magazineCollection2.ToString());


            // State of the listeners 
            Console.WriteLine("******************************************************");
            Console.WriteLine("State of the listeners");
            Console.WriteLine("******************************************************");

            // State of the first listener 
            Console.WriteLine("******************************************************");
            Console.WriteLine("State of the listener for added and replaced events of the first colletion");
            Console.WriteLine("******************************************************");
            Console.WriteLine(listenerAddedReplacedFROMFirst);

            // State of the seconde listener 
            Console.WriteLine("******************************************************");
            Console.WriteLine("State of the listener for added events of the both colletion");
            Console.WriteLine("******************************************************");
            Console.WriteLine(listenerAddedFROMFirstSecond);

        }
    }
}

