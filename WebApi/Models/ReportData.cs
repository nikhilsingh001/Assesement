using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ReportData
    {
        public string Name { get; set; }
        public List<string> ProducttName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public DateTime DOB { get; set; }
    }
}