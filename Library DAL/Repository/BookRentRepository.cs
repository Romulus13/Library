using Library_DAL.Interfaces;
using Library_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Repository
{
    public class BookRentRepository : GenericRepository<BookRent>,IBookRentRepository
    {
        public BookRentRepository(LibraryDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IList<BookRentHistory>> GetHistory(int? bookId = null)
        {

            Expression<Func<BookRent, bool>> expression = bkh => true;
            if (bookId.HasValue && bookId.Value > 0)
            {
                expression = bkh => bkh.BookId == bookId.Value;
            }
           var bookRentHistory = await dbSet
                    .TemporalAll()
                    .Where(expression)
                    .OrderBy(e => EF.Property<DateTime>(e, "PeriodStart"))
                    .Select(
                        e => new BookRentHistory(e, EF.Property<DateTime>(e, "PeriodStart"), EF.Property<DateTime>(e, "PeriodEnd")))
                    .ToListAsync();
            return bookRentHistory;
        }

      
    }
}
