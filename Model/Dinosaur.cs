using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_BIN.Model
{
    public class Dinosaur
    {
        [JsonProperty("height")]
        public double Height { get; set; }
    }
}
