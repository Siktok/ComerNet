using Lyoko.ComerNet.Domain.Entity;
using Lyoko.ComerNet.Domain.Interface;
using Lyoko.ComerNet.Infrastructure.Interface;


namespace Lyoko.ComerNet.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        public Users Authenticate(string username, string password)
        {
            return _usersRepository.Authenticate(username, password);
        }
    }
}
