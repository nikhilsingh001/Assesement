using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class City
    {
        public int cityID { get; set; }
        public string Cityname { get; set; }
        public int StateID { get; set; }
    }
}