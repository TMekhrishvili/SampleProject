using Dapper;
using Domain.Models.Database;
using Domain.Models.PatientModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository.PatientRepository
{
    public class PatientRepository : IPatientRepository
    {
        #region Fields
        private readonly ConnectionStrings _connectionStrings;
        #endregion

        #region Ctor
        /// <summary>
        /// კონსტრუქტორი
        /// </summary>
        /// <param name="connectionStrings"></param>
        public PatientRepository(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }
        #endregion

        #region Methods
        /// <summary>
        /// პაციენტების სია
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PatientResponseModel>> ListGet()
        {
            IEnumerable<PatientResponseModel> response = new List<PatientResponseModel>();
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                response = await connection.QueryAsync<PatientResponseModel>("dbo.PatientListGet",
                    commandType: CommandType.StoredProcedure);
            }
            return response.ToList();
        }

        /// <summary>
        /// პაციენტის შესახებ ინფორმაცია
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public async Task<PatientResponseModel> Get(int PatientID)
        {
            var response = new PatientResponseModel();
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PatientID", PatientID);
                response = await connection.QuerySingleOrDefaultAsync<PatientResponseModel>("dbo.PatientGet",
                    queryParameters,
                    null,
                    200,
                    CommandType.StoredProcedure);
            }
            return response;
        }

        /// <summary>
        /// პაციენტის შენახვა
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public async Task<int> Post(PatientRequestModel model)
        {
            int response;
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@ID", model.ID);
                queryParameters.Add("@FullName", model.FullName);
                queryParameters.Add("@Dob", model.Dob);
                queryParameters.Add("@GenderID", model.GenderID);
                queryParameters.Add("@Phone", model.Phone);
                queryParameters.Add("@Address", model.Address);
                response = await connection.ExecuteScalarAsync<int>("dbo.PatientSet",
                            queryParameters,
                            null,
                            200,
                            CommandType.StoredProcedure);
            }
            return response;
        }

        /// <summary>
        /// პაციენტის წაშლა
        /// </summary>
        /// <param name="PatientID"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int PatientID)
        {
            int response;
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@PatientID", PatientID);
                response = await connection.ExecuteAsync("dbo.PatientDelete",
                    queryParameters,
                    null,
                    200,
                    CommandType.StoredProcedure);
            }
            return Convert.ToBoolean(response);
        }
        #endregion
    }
}
