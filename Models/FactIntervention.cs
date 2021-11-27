using System;
using System.Collections.Generic;
#nullable disable
namespace RocketApi.Models
{
    public partial class FactIntervention
    {
        public long id { get; set; }
        public long employeeID { get; set; }
        public long buildingID { get; set; }
        public long? batteryID { get; set; }
        public long? columnID { get; set; }
        public long? elevatorID { get; set; }
        public DateTime dateAndTimeInterventionStart { get; set; }
        public DateTime dateAndTimeInterventionEnd { get; set; }
        public string result { get; set; }
        public string report { get; set; }
        public string status { get; set; }
    }
}