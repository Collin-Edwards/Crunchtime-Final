using Crunchtime.Data;
using Crunchtime.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Crunchtime.Repositiories
{
    public class UserService : IUserService
    {
        private readonly DbContextClass _dbContextClass;
        public UserService(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public async Task<int> CreateUser(User newUser)
        {
                var userDetails = await Task.Run(() => _dbContextClass.Database.ExecuteSqlRaw("exec registeruser @username, @passwordhash, @email, @isdoduser, @firstname, @lastname",
                    new SqlParameter("@username", newUser.Username),
                    new SqlParameter("@passwordhash", newUser.Passwordhash),
                    new SqlParameter("@email", newUser.Email),
                    new SqlParameter("@isdoduser", newUser.Isdoduser),
                    new SqlParameter("@firstname", newUser.Firstname),
                    new SqlParameter("@lastname", newUser.Lastname)
                ));
            return userDetails;

        }
    }
}
