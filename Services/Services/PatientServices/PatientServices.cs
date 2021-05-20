using Domain.Models.GeneralResponseModel;
using Domain.Models.PatientModel;
using Repository.Repository.PatientRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.PatientServices
{
    public class PatientServices : IPatientServices
    {
        #region Fields
        private readonly IPatientRepository _patientRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// კონსტრუქტორი
        /// </summary>
        /// <param name="patientRepository"></param>
        public PatientServices(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// პაციენტების სია
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponseModel<IEnumerable<PatientResponseModel>>> PatientListGetAsync()
        {
            var response = new GeneralResponseModel<IEnumerable<PatientResponseModel>>();
            try
            {
                response.DatabaseObjectModel = await _patientRepository.PatientListGetAsync();
                response.Status = true;
                response.Message = "Success";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }
        #endregion
    }
}
