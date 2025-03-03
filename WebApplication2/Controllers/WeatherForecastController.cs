using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lyoko.ComerNet.Application.DTO;
using Lyoko.ComerNet.Application.Interface;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherForecastController : Controller
    {

        private readonly ICustomersApplication _customersApplication;

        public WeatherForecastController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region metodos sincronos
        [HttpPost]
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
        [HttpPut]
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

        [HttpDelete("{customresId}")]
        public IActionResult Delete(String customresId)
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

        [HttpGet("{customresId}")]
        public IActionResult Get(String customresId)
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

        [HttpGet]
        public IActionResult GetAll()
        {

            var response = _customersApplication.GetAll();

            if (response.IsSucess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
        #endregion metodos sincronos




        #region metodos Asincronos
        [HttpPost]
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

        #endregion

    }
}
