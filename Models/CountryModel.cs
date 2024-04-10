using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class CountryModel
    {
        public int CID { get; set; }

        public string Country1 { get; set; }

        //public StateModel statesModel { get; set; } // It used to send each country's states with countries using Includes method.
    }
}