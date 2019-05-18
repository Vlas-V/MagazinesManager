using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinesManager
{
    // IComparable and IComparer implementations
    public partial class Edition : IComparable, IComparer<Edition>
    {
    
        // This method implements IComparable interface to sort an array of Editions by name
        public int CompareTo(object obj)
        {
            Edition temp = obj as Edition;
            if (temp != null)
                return editionName.CompareTo(obj);
            else
                throw new ArgumentException("Parameter is not a Car!");
        }

        // This method implements IComparer interface to sort an array of Editons by PublicationDate
        public int Compare(Edition x, Edition y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException();

            if (x.PublicationDate > x.PublicationDate)
                return 1;
            if (x.PublicationDate < x.PublicationDate)
                return -1;
            else
                return 0;
        }

        // This helper class is used to sort an array of Editions by Circulation
        public class CirculationComparer : IComparer<Edition>
        {
            int IComparer<Edition>.Compare(Edition x, Edition y)
            {
                if (x == null || y == null)
                    throw new ArgumentNullException();

                if (x.Circulation > x.Circulation)
                    return 1;
                if (x.Circulation < x.Circulation)
                    return -1;
                else
                    return 0;
            }
        }

        // A custom property to return the correct IComparer interface
        public static IComparer<Edition> SortByCirculation
        { get { return (IComparer<Edition>)new CirculationComparer(); } }
    }
}

