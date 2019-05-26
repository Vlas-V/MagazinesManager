using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public class TestCollection
    {
        // Private Fields
        private List<Edition> listOfKeys = new List<Edition>();
        private List<string> listOfStrings = new List<string>();
        private Dictionary<Edition, Magazine> dictEditionIsKey = new Dictionary<Edition, Magazine>();
        private Dictionary<string, Magazine> dictStringIsKey = new Dictionary<string, Magazine>();

        // Constructor 
        public TestCollection(int n)
        {
            Magazine current = null;
            Edition currentKey = null;

            for (int i = 0; i < n; i++)
            {
                current = NewElement(i);
                currentKey = current.Edition;

                listOfKeys.Add(currentKey);
                listOfStrings.Add(currentKey.ToString());
                dictEditionIsKey.Add(currentKey, current);
                dictStringIsKey.Add(currentKey.ToString(), current);
            }
        }

        // Methods 
        public static Magazine NewElement(int key)
        {
            Magazine newElement = new Magazine
            {
                EditionName = key.ToString(),
                PublicationDate = new DateTime(1800 + key % 220, key % 12 + 1, key % 30 + 1),
                Circulation = (key * 100) % 100_000
            };

            return newElement;
        }

        // Calculation of the search time with a provided key

        public void Benchmarking(Magazine magazine)
        {
            Stopwatch searchTime;
            long milliSec;
            bool contains;

            // List<Tkey>
            searchTime = Stopwatch.StartNew();
            contains = listOfKeys.Contains(magazine.Edition);
            searchTime.Stop();
            milliSec = searchTime.ElapsedMilliseconds;

            Console.WriteLine($"Search time for List<Tkey>: {milliSec} ms");
            Console.WriteLine($"The element has been found: {contains}");
            Console.WriteLine();


            // List<string>
            searchTime = Stopwatch.StartNew();
            contains = listOfStrings.Contains(magazine.Edition.ToString());
            searchTime.Stop();
            milliSec = searchTime.ElapsedMilliseconds;

            Console.WriteLine($"Search time for List<string>: {milliSec} ms");
            Console.WriteLine($"The element has been found: {contains}");
            Console.WriteLine();


            // Dictionary<TKey, TValue> (by key)
            searchTime = Stopwatch.StartNew();
            contains = dictEditionIsKey.ContainsKey(magazine.Edition);
            searchTime.Stop();
            milliSec = searchTime.ElapsedMilliseconds;

            Console.WriteLine($"Search time for Dictionary<TKey, TValue> (by key): {milliSec} ms");
            Console.WriteLine($"The element has been found: {contains}");
            Console.WriteLine();


            // Dictionary<TKey, TValue> (by value)
            searchTime = Stopwatch.StartNew();
            contains = dictEditionIsKey.ContainsValue(magazine);
            searchTime.Stop();
            milliSec = searchTime.ElapsedMilliseconds;

            Console.WriteLine($"Search time for Dictionary<TKey, TValue> (by value): {milliSec} ms");
            Console.WriteLine($"The element has been found: {contains}");
            Console.WriteLine();


            // Dictionary<string, TValue> (by key)
            searchTime = Stopwatch.StartNew();
            contains = dictStringIsKey.ContainsKey(magazine.Edition.ToString());
            searchTime.Stop();
            milliSec = searchTime.ElapsedMilliseconds;

            Console.WriteLine($"Search time for Dictionary<string, TValue> (by key): {milliSec} ms");
            Console.WriteLine($"The element has been found: {contains}");
            Console.WriteLine();


            // Dictionary<string, TValue> (by value)
            searchTime = Stopwatch.StartNew();
            contains = dictStringIsKey.ContainsValue(magazine);
            searchTime.Stop();
            milliSec = searchTime.ElapsedMilliseconds;

            Console.WriteLine($"Search time for Dictionary<string, TValue> (by value): {milliSec} ms");
            Console.WriteLine($"The element has been found: {contains}");
            Console.WriteLine();
        }

     
    }
}