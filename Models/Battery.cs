using System;

namespace RocketApi.Models
{
    public class Battery
    {
        public long Id { get; set; }
        public long BuildingId {get; set; }
        public string Status { get; set; }
    }
}

