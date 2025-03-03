using Lyoko.ComerNet.Transversal.Common;
using Lyoko.ComerNet.Infrastructure.Interface;
using Lyoko.ComerNet.Domain.Entity;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace Lyoko.ComerNet.Infrastructure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CustomersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region métodos síncronos
        public bool Insert(Customers customers)
        {
          using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var paramaters = new DynamicParameters(); //recomendado para Dapper
                paramaters.Add("CustomerID", customers.CustomerID);
                paramaters.Add("CompanyName", customers.CompanyName);
                paramaters.Add("ContactName", customers.ContactName);   
                paramaters.Add("ContactTitle", customers.ContactTitle);
                paramaters.Add("Address", customers.Address);
                paramaters.Add("City", customers.City);
                paramaters.Add("Region", customers.Region);
                paramaters.Add("PostalCode", customers.PostalCode);
                paramaters.Add("Country", customers.Country);
                paramaters.Add("Phone", customers.Phone);
                paramaters.Add("Fax", customers.Fax);

                var result = connection.Execute(query, paramaters, commandType: CommandType.StoredProcedure);

                return result > 0;//devuelve true

            }
        }



        public bool Update(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var paramaters = new DynamicParameters();
                paramaters.Add("CustomerID", customers.CustomerID);
                paramaters.Add("CompanyName", customers.CompanyName);
                paramaters.Add("ContactName", customers.ContactName);
                paramaters.Add("ContactTitle", customers.ContactTitle);
                paramaters.Add("Address", customers.Address);
                paramaters.Add("City", customers.City);
                paramaters.Add("Region", customers.Region);
                paramaters.Add("PostalCode", customers.PostalCode);
                paramaters.Add("Country", customers.Country);
                paramaters.Add("Phone", customers.Phone);
                paramaters.Add("Fax", customers.Fax);
                var result = connection.Execute(query, paramaters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var paramaters = new DynamicParameters();
                paramaters.Add("CustomerID", customerId);
                var result = connection.Execute(query, paramaters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }


        public Customers Get(String customerId)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var paramaters = new DynamicParameters();
                paramaters.Add("CustomerID", customerId);
                var customer = connection.QuerySingle<Customers>(query, paramaters, commandType: CommandType.StoredProcedure);
                return customer;
            }
   
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";
                var customers = connection.Query<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        #endregion


        #region métodos asíncronos
        public async Task <bool>InsertAsync(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersInsert";
                var paramaters = new DynamicParameters(); //recomendado para Dapper
                paramaters.Add("CustomerID", customers.CustomerID);
                paramaters.Add("CompanyName", customers.CompanyName);
                paramaters.Add("ContactName", customers.ContactName);
                paramaters.Add("ContactTitle", customers.ContactTitle);
                paramaters.Add("Address", customers.Address);
                paramaters.Add("City", customers.City);
                paramaters.Add("Region", customers.Region);
                paramaters.Add("PostalCode", customers.PostalCode);
                paramaters.Add("Country", customers.Country);
                paramaters.Add("Phone", customers.Phone);
                paramaters.Add("Fax", customers.Fax);

                var result = await connection.ExecuteAsync(query, paramaters, commandType: CommandType.StoredProcedure);

                return result > 0;//devuelve true

            }
        }



        public async Task<bool> UpdateAsync(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var paramaters = new DynamicParameters();
                paramaters.Add("CustomerID", customers.CustomerID);
                paramaters.Add("CompanyName", customers.CompanyName);
                paramaters.Add("ContactName", customers.ContactName);
                paramaters.Add("ContactTitle", customers.ContactTitle);
                paramaters.Add("Address", customers.Address);
                paramaters.Add("City", customers.City);
                paramaters.Add("Region", customers.Region);
                paramaters.Add("PostalCode", customers.PostalCode);
                paramaters.Add("Country", customers.Country);
                paramaters.Add("Phone", customers.Phone);
                paramaters.Add("Fax", customers.Fax);
                var result =  await connection.ExecuteAsync(query, paramaters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var paramaters = new DynamicParameters();
                paramaters.Add("CustomerID", customerId);
                var result = await connection.ExecuteAsync(query, paramaters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }


        public async Task<Customers> GetAsync(String customerId)
        {

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var paramaters = new DynamicParameters();
                paramaters.Add("CustomerID", customerId);
                var customer = await connection.QuerySingleAsync<Customers>(query, paramaters, commandType: CommandType.StoredProcedure);
                return customer;
            }

        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";
                var customers = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        #endregion

    }
}
