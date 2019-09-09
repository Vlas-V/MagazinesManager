using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

namespace MagazinesManager
{
    /* 
     
     The part of the Person class 
     that facilitates the creation of objects
     with random states

    */

    public partial class Person
    {
        private static List<string> randomNames;
        private static List<string> randomSurnames;
        private static Random r;


        static Person()
        {


            using (StreamReader r = new StreamReader("../../RandomValuesDB/first-names.json"))
            {
                string json = r.ReadToEnd();
                randomNames = JsonConvert.DeserializeObject<List<string>>(json);
            }

            using (StreamReader r = new StreamReader("../../RandomValuesDB/second-names.json"))
            {
                string json = r.ReadToEnd();
                randomSurnames = JsonConvert.DeserializeObject<List<string>>(json);
            }

            r = new Random();

        }
    }
}