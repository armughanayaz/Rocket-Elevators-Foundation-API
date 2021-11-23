using System;

namespace RocketApi.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public DateTime Created_at { get; set; }
    }
}