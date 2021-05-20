using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services.PatientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Controllers
{
    [Route("Patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        #region Fields
        private readonly IPatientServices _patientServices;
        #endregion

        #region Ctor
        /// <summary>
        /// კონსტრუქტორი
        /// </summary>
        /// <param name="patientServices"></param>
        public PatientController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }
        #endregion

        #region Actions
        /// <summary>
        /// პაციენტების სია
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListGet")]
        public async Task<IActionResult> ListGet()
        {
            try
            {
                // 
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// პაციენტის შესახებ ინფორმაცია ID-ის მიხედვით
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int PatientID)
        {
            try
            {
                // 
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// პაციენტის დამატება/რედაქტირება
        /// </summary>
        /// <returns></returns>
        [HttpPost("Post")]
        public async Task<IActionResult> Post()
        {
            try
            {
                // 
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// პაციენტის წაშლა
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int PatientID)
        {
            try
            {
                // 
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
