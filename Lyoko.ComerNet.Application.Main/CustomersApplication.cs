using Lyoko.ComerNet.Application.DTO;
using Lyoko.ComerNet.Application.Interface;
using Lyoko.ComerNet.Domain.Entity;
using Lyoko.ComerNet.Domain.Interface;
using Lyoko.ComerNet.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;



namespace Lyoko.ComerNet.Application.Main
{
    public class CustomersApplication :ICustomersApplication
    {
        public readonly ICustomersDomain _customersDomain;
        public readonly IMapper _mapper;
        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
        }

        #region metodos Síncronos
        public Response<bool> Insert(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();

            try
            {
              
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.Message = "El cliente se ha insertado correctamente";
                    response.IsSucess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                
            }
            return response;
        }
       public Response<bool> Update(CustomersDTO customersDTO)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Update(customer);
                if (response.Data)
                {
                    response.Message = "El cliente se ha actualizado correctamente";
                    response.IsSucess = true;
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }
            return response;

        }
        public Response<bool> Delete(string customersID)
        { 
            var response = new Response<bool>();

            try
            {
               
                response.Data = _customersDomain.Delete(customersID);
                if (response.Data)
                {
                    response.Message = "El cliente se ha eliminado correctamente";
                    response.IsSucess = true;
                }

            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }

            return response;
        }

        public Response<CustomersDTO> Get(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
               if(response.Data != null)
               {
                    response.Message = "Cliente encontrado";
                    response.IsSucess = true;
               }   



            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;

        } 
           public Response<IEnumerable<CustomersDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.Message = "Cliented encontrados";
                    response.IsSucess = true;
                }


            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;


        }

        #endregion

        #region metodos Asíncronos
        public async Task<Response<bool>> InsertAsync(CustomersDTO customerDTO)
        {
            var response = new Response<bool>();

            try
            {

                var customer = _mapper.Map<Customers>(customerDTO);
                response.Data = await _customersDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.Message = "El cliente se ha insertado correctamente";
                    response.IsSucess = true;
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }
            return response;

        }
       public async Task<Response<bool>> UpdateAsync(CustomersDTO customerDTO)
        {
            var response = new Response<bool>();

            try
            {
                var customer = _mapper.Map<Customers>(customerDTO);
                response.Data = await _customersDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.Message = "El cliente se ha actualizado correctamente";
                    response.IsSucess = true;
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;

            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();

            try
            {

                response.Data = await _customersDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.Message = "El cliente se ha eliminado correctamente";
                    response.IsSucess = true;
                }

            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }

            return response;
        }
        

        public async Task<Response<CustomersDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.Message = "Cliente encontrado";
                    response.IsSucess = true;
                }

            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.Message = "Cliented encontrados";
                    response.IsSucess = true;
                }


            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        #endregion

    }
}
