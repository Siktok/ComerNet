using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lyoko.ComerNet.Application.DTO;
using Lyoko.ComerNet.Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Lyoko.ComerNet.Services.WebApi.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones de clientes.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomersApplication _customersApplication;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CustomersController"/>.
        /// </summary>
        /// <param name="customersApplication">La aplicación de clientes.</param>
        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region metodos sincronos
        /// <summary>
        /// Inserta un nuevo cliente.
        /// </summary>
        /// <param name="customerDTO">El cliente a insertar.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest();
            }
            var response = _customersApplication.Insert(customerDTO);

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Actualiza un cliente existente.
        /// </summary>
        /// <param name="customerDTO">El cliente a actualizar.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest();
            }
            var response = _customersApplication.Update(customerDTO);

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Elimina un cliente por su ID.
        /// </summary>
        /// <param name="customresId">El ID del cliente a eliminar.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpDelete("Delete/{customresId}")]
        public IActionResult Delete(string customresId)
        {
            if (string.IsNullOrEmpty(customresId))
            {
                return BadRequest();
            }
            var response = _customersApplication.Delete(customresId);

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Obtiene un cliente por su ID.
        /// </summary>
        /// <param name="customresId">El ID del cliente a obtener.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpGet("Get/{customresId}")]
        public IActionResult Get(string customresId)
        {
            if (string.IsNullOrEmpty(customresId))
            {
                return BadRequest();
            }
            var response = _customersApplication.Get(customresId);

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Obtiene todos los clientes.
        /// </summary>
        /// <returns>El resultado de la operación.</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
        #endregion

        #region metodos Asincronos
        /// <summary>
        /// Inserta un nuevo cliente de forma asincrónica.
        /// </summary>
        /// <param name="customerDTO">El cliente a insertar.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest();
            }
            var response = await _customersApplication.InsertAsync(customerDTO);

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Actualiza un cliente existente de forma asincrónica.
        /// </summary>
        /// <param name="customerDTO">El cliente a actualizar.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest();
            }
            var response = await _customersApplication.UpdateAsync(customerDTO);

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Elimina un cliente por su ID de forma asincrónica.
        /// </summary>
        /// <param name="customresId">El ID del cliente a eliminar.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpDelete("DeleteAsync/{customresId}")]
        public async Task<IActionResult> DeleteAsync(string customresId)
        {
            if (string.IsNullOrEmpty(customresId))
            {
                return BadRequest();
            }
            var response = await _customersApplication.DeleteAsync(customresId);

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Obtiene un cliente por su ID de forma asincrónica.
        /// </summary>
        /// <param name="customresId">El ID del cliente a obtener.</param>
        /// <returns>El resultado de la operación.</returns>
        [HttpGet("GetAsync/{customresId}")]
        public async Task<IActionResult> GetAsync(string customresId)
        {
            if (string.IsNullOrEmpty(customresId))
            {
                return BadRequest();
            }
            var response = await _customersApplication.GetAsync(customresId);

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Obtiene todos los clientes de forma asincrónica.
        /// </summary>
        /// <returns>El resultado de la operación.</returns>
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
        #endregion
    }
}
