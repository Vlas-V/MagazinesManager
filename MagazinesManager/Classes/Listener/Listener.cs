using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinesManager
{
    public class Listener
    {
        private List<ListEntry> listEntries;

        public Listener()
        {
            ListEntries = new List<ListEntry>();
        }


        private List<ListEntry> ListEntries
        {
            get { return listEntries; }
            set { listEntries = value; }
        }

        // Do I even need this method? ????
        private void AddListEntry(ListEntry le)
        {
            ListEntries.Add(le);
        }
        
             
        public void MagazineAddedEventListenerSubscriber(object sender, MagazineCollection.MagazineListHandlerEventArgs e)
        {
            if (sender is MagazineCollection mc)
            {
                ListEntry le = new ListEntry(e.CollectionName, e.ChangeType, e.NumberOfTheElement);
                AddListEntry(le);
            }
        }

        public void MagazineReplacedEventListenerSubscriber(object sender, MagazineCollection.MagazineListHandlerEventArgs e)
        {
            if (sender is MagazineCollection mc)
            {
                ListEntry le = new ListEntry(e.CollectionName, e.ChangeType, e.NumberOfTheElement);
                AddListEntry(le);
            }
        }



        public override string ToString()
        {
            StringBuilder data = new StringBuilder(ListEntries.Count * 512);
            data.AppendLine("[");

            foreach (ListEntry m in ListEntries)
            {
                data.AppendLine("{");
                data.AppendLine(m.ToString().TrimStart('[').TrimEnd(']'));
                data.AppendLine("}");
            }

            data.AppendLine("]");
            return data.ToString();
        }

        private class ListEntry
        {
            public string CollectionName { get; set; }
            public string ChangeType { get; set; }
            public int NumberOfTheElement { get; set; }

            public ListEntry(string collectionName,
                             string changeType,
                             int numberOfTheElement)
            {
                CollectionName = collectionName;
                ChangeType = changeType;
                NumberOfTheElement = numberOfTheElement;
            }

            public override string ToString()
            {
                string info = String.Empty;
                info += "[\n";
                info += $"Colletion's name: {CollectionName}\n";
                info += $"Type of change: {ChangeType}\n";
                info += $"Number of the changed/added element: {NumberOfTheElement}\n";
                info += "]";
                return info;
            }
        }
    }
}
