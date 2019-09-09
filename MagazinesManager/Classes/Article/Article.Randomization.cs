using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace MagazinesManager
{

    /*
     *  This part of the Person class 
     *  facilitates the creation of 
     *  objects with random states
    */

    public partial class Article : IRateAndCopy
    {
        private static List<string> randomNames;
        private static Random r;

        static Article()
        {

            using (StreamReader r = new StreamReader("../../RandomValuesDB/articles-magazines-names.json"))
            {
                string json = r.ReadToEnd();
                randomNames = JsonConvert.DeserializeObject<List<string>>(json);
            }

            r = new Random();

        }
    }
}

