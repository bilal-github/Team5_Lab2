using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Coded by Elias Nahas
namespace SlipsData
{
    public class SlipServices // Slips class with dimensions and services available
    {
        public SlipServices() { }
        public int LeaseID { get; set; }

        public int ID { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }

        public int DockID { get; set; }
        public bool ElectricalService { get; set; }
        public bool WaterService { get; set; }
    }
}