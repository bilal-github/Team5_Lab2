using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlipsData
{
    public class Dock
    {
        public Dock() { }

        public int ID { get; set; }

        public string Name { get; set; }

        public bool WaterService { get; set; }

        public bool ElectricalService { get; set; }
    }
}