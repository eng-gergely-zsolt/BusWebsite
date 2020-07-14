using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusApplication.Models
{
    public class BusPositionViewModel
    {
        public int Id;
        public string BusId;
        public double Latitude;
        public double Longitude;
        public string BusName;
        public DateTime Timestamp;

        public BusPositionViewModel()
        {

        }
    }
}