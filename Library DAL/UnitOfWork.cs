using Library_DAL.Interfaces;
using Library_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Library_DAL { 
    public class UnitOfWork //: IUnitOfWork, IDisposable
    {
        private readonly LibraryDbContext _context;
        private readonly ILogger _logger;

        public IGenericRepository<User> Users => GetRepository<User>();
        public IGenericRepository<UserContact> UserContacts => GetRepository<UserContact>();
        public IGenericRepository<Book> Books => GetRepository<Book>();
        public IGenericRepository<BookRent> BookRents => GetRepository<BookRent>();
        public IGenericRepository<BookInventoryItem> BookInventoryItems => GetRepository<BookInventoryItem>();

        public UnitOfWork(LibraryDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
           
        }

        public void Dispose()
        {
            _context.Dispose();
        }

          

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            var returnInt = await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            
            return returnInt;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context, _logger);
        }

        /*public void DoInTransaction(Action<IUnitOfWork> action, IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            using   (var transaction = _context.Database.BeginTransaction(level))
            {
                try
                {
                    action(this);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback(); 
                    throw;
                }

            }
        }*/
    }
}
