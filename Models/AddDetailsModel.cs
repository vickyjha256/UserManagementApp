using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class AddDetailsModel
    {
        public int PID { get; set; }
        public int UserID { get; set; }
        public string Gender { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }


    }
}