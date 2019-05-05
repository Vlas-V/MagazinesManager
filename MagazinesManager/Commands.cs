using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazinesManager
{
    public interface ICommand
    {
        bool Execute();
    }

    public class ExitCommand : ICommand
    {
        public bool Execute()
        {
            return true;
        }
    }

    public class HelpCommand : ICommand
    {
        public bool Execute()
        {
            Console.WriteLine("Sorry, this programm doesn't have a full functionlity yet.");
            return false;
        }
    }

    public class UndefinedCommand : ICommand
    {
        public bool Execute()
        {
            Console.WriteLine("Command not found. Try typing 'help' for help.");
            return false;
        }
    }

    public class AddMagazineCommand : ICommand
    {
        public bool Execute()
        {
            // Prompt the User for infornation about Magazine

            Magazine newMagazine = new Magazine();


            Console.WriteLine("Name of the magazine:        ");
            newMagazine.Name = Console.ReadLine();

            Console.WriteLine("Frequency of publications:   ");
            newMagazine.Frequency = (Frequency)Enum.Parse(typeof(Frequency), Console.ReadLine());

            Console.WriteLine("Publication Date:            ");
            newMagazine.PublicationDate = new DateTime(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));

            Console.WriteLine("Circulation:                 ");
            newMagazine.Circulation = Int32.Parse(Console.ReadLine());
        

            if (Globals.Magazines == null)
            {
                // 
                Globals.Magazines = new Magazine[1];
                Globals.Magazines[0] = newMagazine;
            }
            else
            {
                // Add the new element
                Magazine[] temp = new Magazine[Globals.Magazines.Length + 1];
                Globals.Magazines.CopyTo(temp, 0);
                temp[temp.Length - 1] = newMagazine;

                Globals.Magazines = temp;
            }

            return false;
        }
    }

    public class MagazinesInfoCommand : ICommand
    {
        public bool Execute()
        {
            Globals.ShowInfo();
            return false;
        }
    }
}
