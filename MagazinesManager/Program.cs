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
            Person p1 = new Person("hello", "world", new DateTime(2001, 01, 12));


            Magazine m1 = new Magazine();
            Article a1 = new Article(p1, "Winter", 77);

            m1.AddArticles(a1);

            Console.WriteLine("Before chage:");
            Console.WriteLine(m1.ToString());

            // Changes in the article
            a1.Rate = 22;

            Console.WriteLine("After chage:");
            Console.WriteLine(m1.ToString());

        }
    }
}

