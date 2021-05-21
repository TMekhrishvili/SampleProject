using Domain.Models.GeneralResponseModel;
using Domain.Models.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.PatientServices
{
    public interface IPatientServices
    {
        public Task<GeneralResponseModel<IEnumerable<PatientResponseModel>>> ListGet();
        public Task<GeneralResponseModel<PatientResponseModel>> Get(int PatientID);
        public Task<GeneralResponseModel<int>> Post(PatientRequestModel model);
        public Task<GeneralResponseModel<Boolean>> Delete(int PatientID);
    }
}
