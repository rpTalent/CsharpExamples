using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebCounters.Models
{
    public class CountersViewModel
    {
        public BaseCounter SessionCounter { get; set; }
        public BaseCounter ApplicationCounter { get; set; }
        public BaseCounter StaticCounter { get; set; }
    }
}