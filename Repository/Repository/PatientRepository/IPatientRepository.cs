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
        public Task<IEnumerable<PatientResponseModel>> ListGet();
        public Task<PatientResponseModel> Get(int PatientID);
        public Task<int> Post(PatientRequestModel model);
        public Task<bool> Delete(int PatientID);
    }
}
