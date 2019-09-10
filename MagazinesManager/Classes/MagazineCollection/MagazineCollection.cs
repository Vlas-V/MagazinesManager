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


        // Delagate 
        public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);
        public class MagazineListHandlerEventArgs : EventArgs
        {
            public string CollectionName { get; set; }
            public string ChangeType { get; set; }
            public int NumberOfChangedElement { get; set; } 

            public MagazineListHandlerEventArgs(string collectionName,
                                                string changeType,
                                                int numberOfChangedElement)
            {
                CollectionName = collectionName;
                ChangeType = changeType;
                NumberOfChangedElement = numberOfChangedElement;
            }

            public override string ToString()
            {
                string info = String.Empty;
                info += "[\n";
                info += $"Colletion's name: {CollectionName}\n";
                info += $"Type of change: {ChangeType}\n";
                info += $"Number of the changed element: {NumberOfChangedElement}\n";
                info += "]";
                return info;
            }
        }

        // Events 
        public event MagazineListHandler MagazineAdded;
        public event MagazineListHandler MagazineReplaced;
        

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
        { for (int i = 0; i < 3; i++) AddMagazines(new Magazine(random: true)); }

        public void AddMagazines(params Magazine[] mags)
        {
            foreach (Magazine m in mags)
            {
                Magazines.Add(m);
                MagazineAdded?.Invoke(this, new MagazineListHandlerEventArgs(Name, "Element added", Magazines.IndexOf(m)));
            }
        }

        public bool Replace(int index, Magazine m)
        {
            if (index >= magazines.Count) return false;
           
            magazines[index] = m;
            MagazineReplaced?.Invoke(this, new MagazineListHandlerEventArgs(Name, "Element replaced", index));
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
                MagazineReplaced?.Invoke(this, new MagazineListHandlerEventArgs(Name, "Element replaced", index));
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