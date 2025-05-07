using AutoMapper;
using Lyoko.ComerNet.Application.DTO;
using Lyoko.ComerNet.Application.Interface;
using Lyoko.ComerNet.Domain.Interface;
using Lyoko.ComerNet.Transversal.Common;
using Lyoko.ComerNet.Application.Validator;


namespace Lyoko.ComerNet.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _usersDtoValidator;

        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDtoValidator usersDtoValidator)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _usersDtoValidator = usersDtoValidator;
        }




        public Response<UsersDTO> Authenticate(string username, string password)
        {
            var response = new Response<UsersDTO>();
            var validationResult = _usersDtoValidator.Validate(new UsersDTO { UserName = username, Password = password });
            if (!validationResult.IsValid)
            {
                response.Message = "Error de validación";
                response.Errors = validationResult.Errors;
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDTO>(user);
                response.IsSucess = true;
                response.Message = "Autenticación exitosa";

            }
            catch (InvalidOperationException)
            {
                response.IsSucess = true;
                response.Message = "Usuario o contraseña no existe"; //propio de dapper debido a que no se encontró el usuario/pass crea una expetion pero se executa correctamente

            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.Message = ex.Message;

            }
            return response;


        }

    }
}
