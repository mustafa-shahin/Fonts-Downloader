using Newtonsoft.Json;
using System.Collections.Generic;

namespace Fonts_Downloader
{
    public class Files
    {
        [JsonProperty("100")]
        public string _100 { get; set; }

        [JsonProperty("200")]
        public string _200 { get; set; }

        [JsonProperty("300")]
        public string _300 { get; set; }

        [JsonProperty("500")]
        public string _500 { get; set; }

        [JsonProperty("600")]
        public string _600 { get; set; }

        [JsonProperty("700")]
        public string _700 { get; set; }

        [JsonProperty("800")]
        public string _800 { get; set; }

        [JsonProperty("900")]
        public string _900 { get; set; }

        [JsonProperty("100italic")]
        public string _100italic { get; set; }

        [JsonProperty("200italic")]
        public string _200italic { get; set; }

        [JsonProperty("300italic")]
        public string _300italic { get; set; }

        [JsonProperty("regular")]
        public string regular { get; set; }

        [JsonProperty("italic")]
        public string italic { get; set; }

        [JsonProperty("500italic")]
        public string _500italic { get; set; }

        [JsonProperty("600italic")]
        public string _600italic { get; set; }

        [JsonProperty("700italic")]
        public string _700italic { get; set; }

        [JsonProperty("800italic")]
        public string _800italic { get; set; }

        [JsonProperty("900italic")]
        public string _900italic { get; set; }
    }

    public class Item
    {
        public string family { get; set; }
        public List<string> variants { get; set; }
        public List<string> subsets { get; set; }
        public string version { get; set; }
        public string lastModified { get; set; }
        public Files files { get; set; }
        public string category { get; set; }
        public string kind { get; set; }
    }

    public class Root
    {
        public string kind { get; set; }
        public List<Item> items { get; set; }
    }
}
