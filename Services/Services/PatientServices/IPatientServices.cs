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
        public Task<GeneralResponseModel<IEnumerable<PatientResponseModel>>> PatientListGetAsync();
    }
}
