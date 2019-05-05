using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinesManager
{
    static class Globals
    {
        static private Magazine[] magazines = null;
        static public Magazine[] Magazines
        {
            get => magazines;
            set
            {
                magazines = value;
            }
        }

        static public void ShowInfo()
        {
            Console.WriteLine("Information about Magazines: ");

            if (Magazines == null)
            {
                Console.WriteLine("No magazines yet.");
                return;
            }

            foreach (Magazine magazine in Magazines)
            {
                Console.WriteLine(magazine.ToString());
            }


        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Person person1 = new Person("Ivan", "Sergov", new DateTime(2019, 12, 2));
            Person person2 = new Person();

            Console.WriteLine(person1.ToShortString());
            Console.WriteLine(person1.ToString());

            Console.WriteLine(person2.ToShortString());
            Console.WriteLine(person2.ToString());

            Article article1 = new Article();
            Article article2 = new Article(person1, "Yla", 18);
            Console.WriteLine(article1.ToString());
            Console.WriteLine(article2.ToString());

            Article[] list = new Article[0];
            Console.WriteLine(list.Length);

            // Arrays Manipulations 

              
            Magazine magazine1 = new Magazine("Herald", Frequency.Monthly, new DateTime(2019, 04, 17), 80_000)
            {
                ArticlesList = new Article[] { article1, article2 }
            };
            magazine1.AddArticles(article1, article2);
            Console.WriteLine(magazine1.ToString());


         


            // 1. Create a new Magazine object and print info 
            Magazine herald = new Magazine("Herald", Frequency.Monthly, new DateTime(2019, 04, 17), 80_000);
            Console.WriteLine(herald.ToShortString());

            // 2. Assign values to all of the fields of the object 
            // Almost done via constructor
            herald.ArticlesList = new Article[] { article1, article2 };
            Console.WriteLine(herald.ToString());

            // 3. Add some new articles to the magazine
            herald.AddArticles(article1, article2);
            Console.WriteLine(herald.ToString());

            // 4. Benchmarking of different arrays
            Console.WriteLine("Pleace provide the information about numbers of rows and columns.");
            Console.WriteLine("You can use different delimeters ' ', ',';'");
            string textInput = Console.ReadLine();

            string[] values = textInput.Split(' ', ',', ';');

            int nrows = Int32.Parse(values[0]);
            int ncolumns = Int32.Parse(values[1]);


            // Create and poputate there arrays

            // One-dimensional array
            Article[] oneDem = new Article[nrows * ncolumns];
            for (int i = 0; i < nrows * ncolumns; i++)
            {
                oneDem[i] = new Article();
            }

            // Two-dimensional array
            Article[,] twoDem = new Article[nrows, ncolumns];
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    twoDem[i, j] = new Article();
                }
            }

            // Jagged array
            Article[][] jagged = new Article[nrows][];
            for (int i = 0; i < nrows; i++)
            {
                jagged[i] = new Article[ncolumns]; 
            }

            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    jagged[i][j] = new Article();
                }
            }

            // Measure time 

            int before, after;

            // one-dimensional
            before = Environment.TickCount;
            for (int i = 0; i < nrows*ncolumns; i++)
            {
                oneDem[i].Name = "name";
            }
            after = Environment.TickCount;

            int oneDemTime = after - before;

            // two-dimensional
            before = Environment.TickCount;
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    twoDem[i, j].Name = "name";
                }
            }
            after = Environment.TickCount;

            int twoDemTime = after - before;

            // jagged
            before = Environment.TickCount;
            for (int i = 0; i < nrows; i++)
            {
                for (int j = 0; j < ncolumns; j++)
                {
                    jagged[i][j].Name = "name";
                }
            }
            after = Environment.TickCount;

            int jaggedTime = after - before;

            Console.WriteLine($"One-dimensional: {oneDemTime}");
            Console.WriteLine($"Two-dimensional: {twoDemTime}");
            Console.WriteLine($"Jagged:          {jaggedTime}");



            var exit = false;
            while (exit == false)
            {
                Console.WriteLine();
                Console.Write("MagazineManager$:");
                var command = Parser.Parse(Console.ReadLine());
                exit = command.Execute();
            }
        }
    }
}

