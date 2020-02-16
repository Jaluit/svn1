using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEMO.Models
{
    public class SalaryViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public short LeaveHours { get; set; }
        public short OverHours { get; set; }
        public int BasicPrice { get; set; }
        public int Price { get; set; }
    }
}