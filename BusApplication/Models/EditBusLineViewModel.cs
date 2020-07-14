using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusApplication.Models
{
    public class EditBusLineViewModel
    {
        public List<BusTrace> Traces { get; set; }
        public List<Station> Stations { get; set; }
        public List<Line> Lines { get; set; }

        public EditBusLineViewModel()
        {
            Traces = new List<BusTrace>();
            Stations = new List<Station>();
            Lines = new List<Line>();
        }
     }

}