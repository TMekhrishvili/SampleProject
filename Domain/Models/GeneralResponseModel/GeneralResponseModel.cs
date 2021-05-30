using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.GeneralResponseModel
{
    public class GeneralResponseModel<T>
    {
        public T Data { get; set; }
        public Boolean Status { get; set; }
        public string Message { get; set; }
    }
}
