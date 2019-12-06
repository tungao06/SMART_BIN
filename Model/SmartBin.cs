using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_BIN.Model
{
    public class SmartBin
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Location Location { get; set; }
    }
}