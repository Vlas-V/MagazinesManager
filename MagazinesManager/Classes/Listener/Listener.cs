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

        private List<ListEntry> ListEntries
        {
            get { return listEntries; }
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
            public int NumberOfChangedElement { get; set; }

            public ListEntry(string collectionName,
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
    }
}
