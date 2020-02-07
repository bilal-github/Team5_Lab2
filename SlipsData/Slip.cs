using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlipsData
{
    public class Slip
    {
        public Slip() { }
        public int LeaseID { get; set; }

        public int ID { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }

        public int DockID { get; set; }
    }
}