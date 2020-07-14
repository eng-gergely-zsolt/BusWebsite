using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusApplication.Models
{
    public class StationViewModel
    {
        public int StationID { get; set; }
        public string StationName { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

    }
}