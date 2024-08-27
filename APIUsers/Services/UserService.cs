using Core.Domain.Entities;
using Core.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace APIUsers.Services
{
    public class UserService : IUser
    {

        private ApplicationDBContext _context;
        public UserService()
        {
            _context = new ApplicationDBContext();
        }
        public async Task AddUsers(Users user)
        {
            //check the email address exist or not

            // This line will add user data and set the database.
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(true);
            }
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUsers(int id, Users user)
        {
            var userObj = await _context.Users.FindAsync(id);

            if (userObj != null)
            {
                userObj.userName = user.userName;
                userObj.email = user.email;
                userObj.address = user.address;
                userObj.Status = user.Status;
            }

            await _context.SaveChangesAsync();
        }
    }
}
