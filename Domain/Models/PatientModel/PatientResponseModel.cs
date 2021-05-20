using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.PatientModel
{
    public class PatientResponseModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public int GenderID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
