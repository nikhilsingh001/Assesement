using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace WebApi.Models
{
    public class customer
    {
        public string Name { get; set; }
        public List<int>  ProductId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public DateTime DOB { get; set; }

    }
}