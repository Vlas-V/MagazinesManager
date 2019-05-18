using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public partial class Edition : IComparable, IComparer<Edition>
    {
        protected string editionName;
        protected DateTime publicationDate;
        protected int circulation;

        public Edition(string editionName = "",
                        DateTime publicationDate = new DateTime(),
                        int cirulation = 0)
        {
            EditionName = editionName;
            PublicationDate = publicationDate;
            Circulation = cirulation;
        }

        public string EditionName
        {
            get => editionName;
            set
            {
                editionName = value;
            }
        }

        public DateTime PublicationDate
        {
            get => publicationDate;
            set
            {
                publicationDate = value;
            }
        }

        public int Circulation
        {
            get => circulation;
            set
            {
                if (value < 0)
                {
                    string message = "The circluation value must be a natural nubmer.";
                    throw new ArgumentOutOfRangeException(message);
                }

                circulation = value;

            }
        }

        public override string ToString()
        {
            return $"[Edition Name: {EditionName};\n" +
                     $"Publication Date: {PublicationDate}\n; " +
                     $"Circulation: {Circulation}]";
        }

        public override int GetHashCode() => this.ToString().GetHashCode();
        public override bool Equals(object obj) => obj?.ToString() == this.ToString();
        public static bool operator ==(Edition e1, Edition e2) => e1.Equals(e2);
        public static bool operator !=(Edition e1, Edition e2) => !e1.Equals(e2);


        public virtual object DeepCopy()
        {
            return new Edition(this.EditionName, this.PublicationDate, this.Circulation);
        }

    }
}