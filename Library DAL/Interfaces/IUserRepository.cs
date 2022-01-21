using Library_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<TopOverdueUsers>> GetMostOverdueUsers();
    }
}
