using Microsoft.AspNetCore.Mvc;
using Services.Services.GenderServices;
using System;
using System.Threading.Tasks;

namespace Test.Controllers
{
    [Route("Gender")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        #region Fields
        private readonly IGenderServices _genderServices;
        #endregion

        #region Ctor
        /// <summary>
        /// კონსტრუქტორი
        /// </summary>
        /// <param name="genderServices"></param>
        public GenderController(IGenderServices genderServices)
        {
            _genderServices = genderServices;
        }
        #endregion

        #region Methods
        [HttpGet("ListGet")]
        public async Task<IActionResult> ListGet()
        {
            try
            {
                var generalResponseModel = await _genderServices.ListGet();
                if (generalResponseModel.Status)
                    return Ok(generalResponseModel);

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
