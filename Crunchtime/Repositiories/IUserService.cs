using Crunchtime.Entities;

namespace Crunchtime.Repositiories
{
    public interface IUserService
    {

        public Task<int> CreateUser(User newUser);
    }
}
