using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public class MagazineCollection
    {
        private List<Magazine> magazines = new List<Magazine>();

        public List<Magazine> Magazines
        {
            // Reference of value?
            get { return magazines; }
        }


        void AddDefaults()
        {
            Magazine mag1 = new Magazine();
            Magazine mag2 = new Magazine();
            Magazine mag3 = new Magazine();

            AddMagazines(mag1, mag2, mag3);
        }

        void AddMagazines(params Magazine[] mags)
        {
            Magazines.AddRange(mags);
        }

        public override string ToString()
        {
            StringBuilder data = new StringBuilder(Magazines.Count * 512);
            data.AppendLine("[");

            foreach (Magazine m in Magazines)
            {
                data.AppendLine("{");
                data.AppendLine(m.ToString().TrimStart(']').TrimEnd(']') + ";");
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
                data.AppendLine(m.ToShortString().TrimStart(']').TrimEnd(']') + ";");
                data.AppendLine("}");
            }

            data.AppendLine("]");
            return data.ToString();
        }


        // Methods for sorting

        void SortByName()
        {
            Magazines.Sort();
        }

        void SortByPublicationDate()
        {
            Magazines.Sort((IComparer<Edition>)new Magazine());
        }

        void SortByCirculation()
        {
            Magazines.Sort(Magazine.SortByCirculation);
        }


    }
}