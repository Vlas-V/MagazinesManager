using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public partial class Edition : IComparable, IComparer<Edition>
    {
        protected string editionName;
        protected DateTime publicationDate;
        protected int circulation;


        // Randomization 

        private static List<string> randomNames;
        protected static Random r;

        static Edition()
        {

            using (StreamReader r = new StreamReader("../../RandomValuesDB/articles-magazines-names.json"))
            {
                string json = r.ReadToEnd();
                randomNames = JsonConvert.DeserializeObject<List<string>>(json);
            }

            r = new Random();

        }

        public Edition(string editionName = "",
                        DateTime publicationDate = new DateTime(),
                        int cirulation = 0,
                        Boolean random = false)
        {
            if (random)
            {
                EditionName = randomNames[r.Next(randomNames.Count)] + " ed.";
                PublicationDate = new DateTime(1900 + r.Next(121), r.Next(1, 13), r.Next(1, 29));
                Circulation = r.Next(1, 101)*1000;
            }
            else
            {
                EditionName = editionName;
                PublicationDate = publicationDate;
                Circulation = cirulation;
            }
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
            return $"[\nEdition Name: {EditionName};\n" +
                     $"Publication Date: {PublicationDate};\n" +
                     $"Circulation: {Circulation};]";
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