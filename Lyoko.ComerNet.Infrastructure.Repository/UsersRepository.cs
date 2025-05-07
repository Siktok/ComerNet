using Dapper;
using Lyoko.ComerNet.Domain.Entity;
using Lyoko.ComerNet.Infrastructure.Interface;
using Lyoko.ComerNet.Transversal.Common;


namespace Lyoko.ComerNet.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Users Authenticate(string username, string password)
        {
           using(var connection = _connectionFactory.GetConnection)
            {
                var query = "UsersGetByUserAndPassword";
                var parameter = new DynamicParameters();
                parameter.Add("@UserName", username);
                parameter.Add("@Password", password);
                var result = connection.QuerySingle<Users>(query, param: parameter, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }

          
          
        }
    }
}
