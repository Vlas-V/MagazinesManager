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
            throw new NotImplementedException();
        }

        void AddMagazines(params Magazine[] mags)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public string ToShortString()
        {
            return base.ToString();
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