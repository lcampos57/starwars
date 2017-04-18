using System.Collections.Generic;
using Newtonsoft.Json;

namespace starwars.Modelo
{
    [JsonObject("Result")]
    public class Films
    {
        public string title { get; set; }
        public int episode_id { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
    }

    public class RootObjectFilm
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }

        [JsonProperty("results")]
        public List<Films> Films { get; set; }
    }
}
