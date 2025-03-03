using Lyoko.ComerNet.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lyoko.ComerNet.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        public readonly IConfiguration _configuration;

        //inyecccion de dependencias a través de constructor
        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       
        public IDbConnection GetConnection
        {
            get
            {
                var sqlconnection = new SqlConnection();
                if (sqlconnection == null) return null;
                sqlconnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
                sqlconnection.Open();
                return sqlconnection;
            }
        }
    }
}
