using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MagazinesManager
{
    public class Magazine : Edition, IRateAndCopy, ICollection<Article>
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
            Magazine copy =  new Magazine(this.EditionName, this.PublicationDate, this.Circulation, this.Frequency);

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

        // Iterators

        public Article this[int index]
        {
            get { return (Article)Articles[index]; }
            set { Articles[index] = value; }
        }

        // Iterates over all of the articles
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Articles.GetEnumerator();
        }

        // Iterates over Articles with rating higher provided value
        public IEnumerable ArticlesHigher(double rating)
        {
            return actualImplementation();

            IEnumerable actualImplementation()
            {
                foreach (Article a in Articles)
                {
                    if (a.Rating > rating)
                    {
                        yield return a;
                    }
                }
            }
        }

        // Iterates over Articles with a provided keyword in their name
        public IEnumerable ArticlesWith(string keyword)
        {
            return actualImplementation();

            IEnumerable actualImplementation()
            {
                foreach (Article a in Articles)
                {
                    if (a.Name.Contains(keyword))
                    {
                        yield return a;
                    }
                }
            }
        }

        // ICollection interface implementation


        public int Count => Articles.Count;

        public bool IsReadOnly => false;


        public void Add(Article item)
        {
            AddArticles(item);
        }

        public void Clear()
        {
            Articles.Clear();
        }

        public bool Contains(Article item)
        {
            bool found = false;

            foreach (Article art in Articles)
            {
                if (item.Equals(art))
                {
                    found = true;
                }
            }

            return found;
        }

        public void CopyTo(Article[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < Articles.Count; i++)
            {
                array[i + arrayIndex] = Articles[i];
            }
        }

        public bool Remove(Article item)
        {
            bool result = false;

            for (int i = 0; i < Articles.Count; i++)
            {
                Article curArticle = (Article)Articles[i];

                if (item.Equals(curArticle))
                {
                    Articles.RemoveAt(i);
                    result = true;
                    break;
                }
            }

            return result;
        }


        public IEnumerable ArticlesWithAuthorFromMagazine()
        {
            return actualImplementation();

            IEnumerable actualImplementation()
            {
                foreach (Article art in Articles)
                {
                    bool authorFromTheMagazine = false;

                    foreach (Person ed in Editors)
                    {
                        if(art.Author == ed)
                        {
                            authorFromTheMagazine = true;
                            break;
                        }
                    }

                    if (!authorFromTheMagazine)
                    {
                        yield return art;
                    }
                }
            }
        }

        public class MagazineEnumerator : IEnumerator<Article>
        {
            private List<Article> _collection; // Magazine == collections of articles
            private int curIndex;
            private Article curBox;

            private int index = 0;

            private List<Person> editors;


            public MagazineEnumerator(Magazine magazine)
            {
                _collection = magazine.Articles;
                curIndex = -1;
                curBox = default(Article);

                editors = magazine.Editors;

            }

            public bool MoveNext()
            {
                //Avoids going beyond the end of the collection.
                if (++curIndex >= _collection.Count)
                {
                    return false;
                }
                else
                {

                    for (int i = curIndex; i < _collection.Count; i++)
                    {
                        bool authorFromTheMagazine = false;

                        foreach (Person ed in editors)
                        {

                            if (_collection[curIndex].Author == ed)
                            {
                                authorFromTheMagazine = true;
                                break;
                            }
                        }

                        if (!authorFromTheMagazine)
                        {
                            // Set current box to next item in collection
                            curBox = _collection[curIndex];
                            return true;
                        }

                        curIndex++;
                    }

                    return false;
                }
            }

            public void Reset() { curIndex = -1; }

            void IDisposable.Dispose() { }

            public Article Current
            {
                get { return curBox; }
            }


            object IEnumerator.Current
            {
                get { return Current; }
            }

        }

        public IEnumerator<Article> GetEnumerator()
        {
            return new Magazine.MagazineEnumerator(this);
        }


        public IEnumerable EditorsWithoutArticles()
        {
            return actualImplementation();

            IEnumerable actualImplementation()
            {
                foreach (Person ed in Editors)
                {
                    bool isAuthor = false;

                    foreach (Article art in Articles)
                    {
                        if (ed == art.Author)
                        {
                            isAuthor = true;
                            break;
                        }
                    }

                    if (!isAuthor)
                    {
                        yield return ed;
                    }
                }
            }
        }

    }
}

