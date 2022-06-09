using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTesting2.Models
{
    public class UpdateEmployeRequest
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int salary { get; set; }
        public int age { get; set; }
        public string profile_image { get; set; }
    }
}
