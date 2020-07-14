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
    
    public partial class BusDriverData
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public System.DateTime Measurement_Timestamp { get; set; }
        public double Position_Accuracy { get; set; }
        public double Speed { get; set; }
        public double Speed_Accuracy { get; set; }
        public int Direction { get; set; }
        public double Accel_x { get; set; }
        public double Accel_y { get; set; }
        public double Accel_z { get; set; }
        public double Gyro_x { get; set; }
        public double Gyro_y { get; set; }
        public double Gyro_z { get; set; }
        public string BusId { get; set; }
        public int Trace_Match { get; set; }
    
        public virtual Bus Bus { get; set; }
    }
}
