using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace MagazinesManager
{
    // Iterators 
    public partial class Magazine : Edition, IRateAndCopy, IEnumerable
    {

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

        // Iterates over Articles with author being an editor in the magazine
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
                        if (art.Author == ed)
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

        // The iterator over Editors without articles in the Magazine
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

        // Iterates over Articles without author being an editor in the magazine
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Magazine.MagazineEnumerator(this);
        }

        // Helper class that implements IEnumerator to iterate over articles
        // with author being an editor in the Magazine 
        public class MagazineEnumerator : IEnumerator<Article>
        {
            private List<Article> _collection; // Magazine == collections of articles
            private int curIndex;
            private Article curBox;


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

    }
}

