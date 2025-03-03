using Lyoko.ComerNet.Domain.Entity;
using Lyoko.ComerNet.Domain.Interface;
using Lyoko.ComerNet.Infrastructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Lyoko.ComerNet.Domain.Core
{
    public class CustomersDomain: ICustomersDomain
    {
        private readonly ICustomersRepository _customersRepository;

            public CustomersDomain(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        #region metodos Síncronos
        public bool Insert(Customers customer)
        {
            return _customersRepository.Insert(customer);
        }
        #endregion

        public bool Update(Customers customer)
        {
            return _customersRepository.Update(customer);
        }

        public bool Delete(string customerId)
        {
            return _customersRepository.Delete(customerId);
        }

        public Customers Get(string customerId)
        {
            return _customersRepository.Get(customerId);
        }
        public IEnumerable<Customers> GetAll() {
        
            return _customersRepository.GetAll();
        }

        #region metodos Asíncronos
        public Task<bool> InsertAsync(Customers customer)
        {
            return _customersRepository.InsertAsync(customer);
        }

        public Task<bool> UpdateAsync(Customers customer)
        {
            return _customersRepository.UpdateAsync(customer);
        }

        public Task<bool> DeleteAsync(string customerId)
        {
            return _customersRepository.DeleteAsync(customerId);
        }

        public Task<Customers> GetAsync(string customerId)
        {
            return _customersRepository.GetAsync(customerId); 
        }

        public Task<IEnumerable<Customers>> GetAllAsync()
        {
            return _customersRepository.GetAllAsync();
        }

        #endregion 
    }
}
