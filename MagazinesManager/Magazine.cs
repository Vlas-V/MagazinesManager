using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    public class Magazine : Edition, IRateAndCopy
    {
        private string name;
        private Frequency frequency;
        private Article[] articlesList;

        // Single constructor using optional parameters
        public Magazine(string name = "",
                        Frequency frequency = 0,
                        DateTime publicationDate = new DateTime(),
                        int circulation = 0)
        {
            Name = name;
            Frequency = frequency;
            PublicationDate = publicationDate;
            Circulation = circulation;

            // Other default values
            ArticlesList = null;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }

        public Frequency Frequency
        {
            get => frequency;
            set
            {
                frequency = value;
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
                circulation = value;
            }
        }

        public Article[] ArticlesList
        {
            get => articlesList;
            set
            {
                articlesList = value;
            }
        }

        public double AverageRate
        {
            get
            {
                if (ArticlesList == null)
                    return 0;

                double sum = 0;

                foreach (Article article in ArticlesList)
                    sum += article.Rating;

                return sum / ArticlesList.Length;
            }
        }

        double IRateAndCopy.Rating => throw new NotImplementedException();

        public void AddArticles(params Article[] articles)
        {
            if (ArticlesList == null)
            {
                ArticlesList = articles;
            }
            else
            {
                ArticlesList = ArticlesList.Concat(articles).ToArray();
            }

        }

        public override string ToString()
        {
            string info = "";
            info += "Magazine's name:       " + Name + "\n";
            info += "Production frequency:  " + Frequency + "\n";
            info += "Publication date:      " + PublicationDate + "\n";
            info += "Circulation:           " + Circulation + "\n";
            info += "ARTICLES\n\n";
            info += "Average rating:        " + AverageRate + "\n";
            info += "Number of articles:    " + (ArticlesList?.Length ?? 0) + "\n\n";

            if (ArticlesList != null)
            {
                foreach (Article article in ArticlesList)
                    info += article.ToString() + "\n\n";
            }


            return info;
        }

        public string ToShortString()
        {
            string info = "";
            info += "Magazine's name:       " + Name + "\n";
            info += "Production frequency:  " + Frequency + "\n";
            info += "Publication date:      " + PublicationDate + "\n";
            info += "Circulation:           " + Circulation + "\n";
            info += "Average rating:        " + AverageRate + "\n";

            return info;
        }

        object IRateAndCopy.DeepCopy()
        {
            throw new NotImplementedException();
        }
    }
}