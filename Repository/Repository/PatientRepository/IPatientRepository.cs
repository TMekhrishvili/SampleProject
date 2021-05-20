using Domain.Models.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.PatientRepository
{
    public interface IPatientRepository
    {
        public Task<IEnumerable<PatientResponseModel>> PatientListGetAsync();
    }
}
