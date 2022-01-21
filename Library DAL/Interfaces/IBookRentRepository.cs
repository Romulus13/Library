using Library_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Interfaces
{
    public interface IBookRentRepository : IGenericRepository<BookRent>
    {

        Task<IList<BookRentHistory>> GetHistory(int? bookId = null);

        
    }
}
