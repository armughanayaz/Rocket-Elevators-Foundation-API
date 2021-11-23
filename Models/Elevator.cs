using System;


namespace RocketApi.Models
{
    public class Elevator
    {
        public long Id { get; set; }
        public string serialNumber { get; set; }
        public string model { get; set; }
        public string status { get; set; }
        public DateTime dateCommissioning { get; set; }
        public DateTime dateLastInspection { get; set; }
        public string certificateOperations { get; set; }
        public string information { get; set; }
        public string notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public long? ColumnId { get; set; }


    }
    
}