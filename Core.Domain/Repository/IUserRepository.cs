using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IUserRepository
    {
        // Return list of Users
        Task<List<Users>> GetAllUsers();        
        Task<Users> GetUserById(int id);        
        Task AddUsers(Users user);        
        Task UpdateUsers(int id, Users user);        
        Task DeleteUser(int id);
    }
}
