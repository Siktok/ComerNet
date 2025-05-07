using Lyoko.ComerNet.Domain.Entity;


namespace Lyoko.ComerNet.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
