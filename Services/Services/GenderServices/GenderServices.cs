using Domain.Models.GenderModel;
using Domain.Models.GeneralResponseModel;
using Repository.Repository.GenderRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.GenderServices
{
   public class GenderServices : IGenderServices
    {
        #region Fields
        private readonly IGenderRepository __genderRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// კონსტრუქტორი
        /// </summary>
        /// <param name="_genderRepository"></param>
        public GenderServices(IGenderRepository _genderRepository)
        {
            __genderRepository = _genderRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// პაციენტების სია
        /// </summary>
        /// <returns></returns>
        public async Task<GeneralResponseModel<IEnumerable<GenderResponseModel>>> ListGet()
        {
            var response = new GeneralResponseModel<IEnumerable<GenderResponseModel>>();
            try
            {
                response.Data = await __genderRepository.ListGet();
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
