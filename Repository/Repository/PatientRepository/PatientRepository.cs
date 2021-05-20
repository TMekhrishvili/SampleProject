using Dapper;
using Domain.Models.Database;
using Domain.Models.PatientModel;
using Microsoft.Extensions.Options;
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
        public async Task<IEnumerable<PatientResponseModel>> PatientListGetAsync()
        {
            IEnumerable<PatientResponseModel> response = new List<PatientResponseModel>();
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                var queryParameters = new DynamicParameters();
                response = await connection.QueryAsync<PatientResponseModel>("",
                    commandType: CommandType.StoredProcedure);
            }
            return response.ToList();
        }

        #endregion
    }
}
