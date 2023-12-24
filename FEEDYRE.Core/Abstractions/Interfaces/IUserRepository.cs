using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEDYRE.Core.Models;

namespace FEEDYRE.Core.Abstractions.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task Create(User user);
    }
}
