using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public class MagazineCollection<TKey>
    {
        private List<Magazine> magazines;
        private Dictionary<TKey, Magazine> magazinesDict;
        public string Name { get; set; }


        public MagazineCollection(string name = "", params Magazine[] mags)
        {
            Name = name;
            magazines = new List<Magazine>();
            magazinesDict = new Dictionary<TKey, Magazine>();
        
            // What if there is nothing in the params ? 
            AddMagazines(mags);
        }

        public List<Magazine> Magazines
        {
            get { return magazines; }
        }

        public Dictionary<TKey, Magazine> MagazinesDict
        {
            get { return magazinesDict; };
        }


        void AddDefaults()
        {
            Magazine mag1 = new Magazine();
            Magazine mag2 = new Magazine();
            Magazine mag3 = new Magazine();

            AddMagazines(mag1, mag2, mag3);
        }

        public void AddMagazines(params Magazine[] mags)
        {
            Magazines.AddRange(mags);
        }

        public bool Replace(Magazine mold, Magazine mnew)
        {
            // ! Working with a private field here !

            // Is it possible to find the old element via key here? 

            foreach (Magazine m in MagazinesDict.Values)
            {
                if(m == mold)
                {
                    // Still need to get the key .... 
                }
            }


            return false; 
        }

        public List<Magazine> WeeklyMagazines()
        {
            List<Magazine> weeklyMagazines = new List<Magazine>();

            foreach (Magazine m in MagazinesDict.Values)
            {
                if (m.Frequency == Frequency.Weekly)
                {
                    weeklyMagazines.Add(m);
                }
            }

            return weeklyMagazines;
        }


        public override string ToString()
        {
            StringBuilder data = new StringBuilder(Magazines.Count * 512);
            data.AppendLine("[");

            foreach (Magazine m in Magazines)
            {
                data.AppendLine("{");
                data.AppendLine(m.ToString().TrimStart('[').TrimEnd(']'));
                data.AppendLine("}");
            }

            data.AppendLine("]");
            return data.ToString();
        }

        public string ToShortString()
        {
            StringBuilder data = new StringBuilder(Magazines.Count * 128);
            data.AppendLine("[");

            foreach (Magazine m in Magazines)
            {
                data.AppendLine("{");
                data.AppendLine(m.ToShortString().TrimStart('[').TrimEnd(']'));
                data.AppendLine("}");
            }

            data.AppendLine("]");
            return data.ToString();
        }


        // Methods for sorting
        public void SortByName()
        {
            Magazines.Sort();
        }

        public void SortByPublicationDate()
        {
            Magazines.Sort((IComparer<Edition>)new Magazine());
        }

        public void SortByCirculation()
        {
            Magazines.Sort(Magazine.SortByCirculation);
        }


    }
}