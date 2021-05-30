using Dapper;
using Domain.Models.Database;
using Domain.Models.GenderModel;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.GenderRepository
{
    public class GenderRepository : IGenderRepository
    {
        #region Fields
        private readonly ConnectionStrings _connectionStrings;
        #endregion

        #region Ctor
        /// <summary>
        /// კონსტრუქტორი
        /// </summary>
        /// <param name="connectionStrings"></param>
        public GenderRepository(IOptions<ConnectionStrings> connectionStrings)
        {
            _connectionStrings = connectionStrings.Value;
        }
        #endregion

        #region Methods
        /// <summary>
        /// პაციენტების სია
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GenderResponseModel>> ListGet()
        {
            IEnumerable<GenderResponseModel> response = new List<GenderResponseModel>();
            using (var connection = new SqlConnection(_connectionStrings.DBConnectionString))
            {
                connection.Open();
                response = await connection.QueryAsync<GenderResponseModel>("dbo.GenderListGet",
                    commandType: CommandType.StoredProcedure);
            }
            return response.ToList();
        }
        #endregion
    }
}
