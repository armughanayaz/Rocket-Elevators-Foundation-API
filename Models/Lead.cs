using System;

namespace RocketApi.Models
{
    public class Lead
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Created_at { get; set; }
   
    }
}
