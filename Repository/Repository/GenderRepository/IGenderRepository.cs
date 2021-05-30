using Domain.Models.GenderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.GenderRepository
{
    public interface IGenderRepository
    {
        public  Task<IEnumerable<GenderResponseModel>> ListGet();
    }
}
