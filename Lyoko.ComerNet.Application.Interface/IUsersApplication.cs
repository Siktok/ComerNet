using Lyoko.ComerNet.Application.DTO;
using Lyoko.ComerNet.Transversal.Common;

namespace Lyoko.ComerNet.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDTO> Authenticate(string username, string password);
        
    }
}
