﻿using System.Collections.Generic;
using Newtonsoft.Json;


namespace starwars.Modelo
{

    public class RootObjectPerson
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }

        //public List<string> films { get; set; }
        //public List<string> species { get; set; }
        //public List<string> vehicles { get; set; }
        //public List<string> starships { get; set; }
        //public string created { get; set; }
        //public string edited { get; set; }
        //public string url { get; set; }
        //public IEnumerable Person { get; internal set; }
    }

}
