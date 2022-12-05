using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
     public class Player
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        public int Goals { get; set; } = 0;

        public int YellowCards { get; set; }

        public override string ToString() => Name;

        public string Format() => $"{Name}   {ShirtNumber}   {Position} ";
        
    }

}
