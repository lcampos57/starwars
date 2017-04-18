using System.Collections.Generic;
using Newtonsoft.Json;

namespace starwars.Modelo
{
    [JsonObject("Result")]
    public class Planets
    {
        public string name { get; set; }
        public int namerotation_period { get; set; }
        public int orbital_period { get; set; }
        public int diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
    }

    public class RootObjectPlanet
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }

        [JsonProperty("results")]
        public List<Planets> Planets { get; set; }
    }
}
