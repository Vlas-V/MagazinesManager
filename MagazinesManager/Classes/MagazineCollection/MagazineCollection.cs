using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public class MagazineCollection
    {
        private List<Magazine> magazines = new List<Magazine>();

        public string Name { get; set; }

        public List<Magazine> Magazines
        {
            // Reference of value?
            get { return magazines; }
        }

        public MagazineCollection(string name = "")
        {
            Name = name;
            magazines = new List<Magazine>();
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

        public bool Replace(int j, Magazine mg)
        {
            if (j >= magazines.Count) return false;

            magazines[j] = mg;
            return true;
        }

        public Magazine this[int index]
        {
            get
            {
                return magazines[index];
            }

            set
            {
                magazines[index] = value;
            }
        }
 

        public override string ToString()
        {
            StringBuilder data = new StringBuilder(Magazines.Count * 512);
            data.AppendLine("[");
            data.AppendLine($"Collection's name: {Name};");

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