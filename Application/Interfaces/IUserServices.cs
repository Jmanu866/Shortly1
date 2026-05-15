using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shortly.Domain.Entities;

namespace Shortly.Aplication.Interfaces
{
    public interface IUserServices
    {
        Task<User> Register(User? user);

        Task<List<User>> GetAllUsers();
    }
}