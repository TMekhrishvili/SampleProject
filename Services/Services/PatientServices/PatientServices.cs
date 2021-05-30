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
        public async Task<GeneralResponseModel<IEnumerable<PatientResponseModel>>> ListGet()
        {
            var response = new GeneralResponseModel<IEnumerable<PatientResponseModel>>();
            try
            {
                response.Data = await _patientRepository.ListGet();
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

        /// <summary>
        /// პაციენტის შესახებ ინფორმაცია
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel<PatientResponseModel>> Get(int PatientID)
        {
            var response = new GeneralResponseModel<PatientResponseModel>();
            try
            {
                response.Data = await _patientRepository.Get(PatientID);
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

        /// <summary>
        /// პაციენტის შენახვა
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel<int>> Post(PatientRequestModel model)
        {
            var response = new GeneralResponseModel<int>();
            try
            {
                response.Data = await _patientRepository.Post(model);
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

        /// <summary>
        /// პაციენტის წაშლა
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel<Boolean>> Delete(int PatientID)
        {
            var response = new GeneralResponseModel<Boolean>();
            try
            {
                response.Data = await _patientRepository.Delete(PatientID);
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
