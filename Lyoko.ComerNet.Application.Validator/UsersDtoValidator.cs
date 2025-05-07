using FluentValidation;
using Lyoko.ComerNet.Application.DTO;

namespace Lyoko.ComerNet.Application.Validator
{
    public class UsersDtoValidator : AbstractValidator<UsersDTO>
    {

    
       public UsersDtoValidator() {
            RuleFor(x => x.UserName).NotNull().WithMessage("No puede ser nulo").NotEmpty().WithMessage("No puede estar vacío");
            RuleFor(x => x.Password).NotNull().NotEmpty();
         

        }
    }
}
