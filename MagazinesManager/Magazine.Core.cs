﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinesManager
{
    public partial class Magazine
    {
        private Frequency frequency;
        private List<Person> editors = new List<Person>();
        private List<Article> articles = new List<Article>();


        // Single constructor using optional parameters
        public Magazine(string editionName = "",
                        DateTime publicationDate = new DateTime(),
                        int circulation = 0,
                        Frequency frequency = 0)
            : base(editionName, publicationDate, circulation)
        {
            Frequency = frequency;
        }

        public Frequency Frequency
        {
            get => frequency;
            set
            {
                frequency = value;
            }
        }

        public List<Person> Editors
        {
            get => editors;
            set
            {
                editors = value;
            }
        }

        public List<Article> Articles
        {
            get => articles;
            set
            {
                articles = value;
            }
        }

        public double AverageRate
        {
            get
            {
                if (Articles?.Any() != true)
                    return 0;

                double sum = 0;

                foreach (Article article in Articles)
                    sum += article.Rating;

                return sum / Articles.Count;
            }
        }

        public Edition Edition
        {
            get => new Edition(this.editionName, this.PublicationDate, this.Circulation);
            set
            {
                this.EditionName = value.EditionName;
                this.PublicationDate = value.PublicationDate;
                this.Circulation = value.Circulation;
            }

        }

        double IRateAndCopy.Rating => AverageRate;


        // Methods
        public void AddEditors(params Person[] editors)
        {
            Editors.AddRange(editors);
        }

        public void AddArticles(params Article[] articles)
        {
            Articles.AddRange(articles);
        }

        public string ToShortString()
        {
            return base.ToString().TrimEnd(']') + '\n' +
                    $"Production frequency: {Frequency};\n" +
                    $"Average rating: {AverageRate};]";
        }

        public override string ToString()
        {

            StringBuilder data = new StringBuilder(512);


            data.AppendLine(ToShortString().TrimEnd(']'));

            data.AppendLine("Editors: ");
            foreach (Person p in Editors)
            {
                data.AppendLine(p.ToShortString() + ',');
            }

            data.Append(";\n");

            data.AppendLine("Articles: ");
            foreach (Article a in Articles)
            {
                data.AppendLine(a.Name + ',');
            }

            return data.ToString().TrimEnd(',') + ";\n]";
        }


        public override object DeepCopy()
        {
            Magazine copy = new Magazine(this.EditionName, this.PublicationDate, this.Circulation, this.Frequency);

            foreach (Person e in Editors)
            {
                copy.AddEditors((Person)e.DeepCopy());
            }

            foreach (Article a in Articles)
            {
                copy.AddArticles((Article)a.DeepCopy());
            }

            return copy;
        }
    }
}