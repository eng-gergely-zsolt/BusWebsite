//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusPosition
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public System.DateTime Timestamp { get; set; }
        public string BusId { get; set; }
        public Nullable<int> Datapoints_nearby { get; set; }
    
        public virtual Bus Bus { get; set; }
    }
}
