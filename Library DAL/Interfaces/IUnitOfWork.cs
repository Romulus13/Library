using Library_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        IGenericRepository<UserContact> UserContacts { get; }

        IBookRentRepository BookRents { get; }

        IGenericRepository<BookInventoryItem> BookInventoryItems { get; }

        IGenericRepository<Book> Books { get; }

        Task<int> SaveAsync(CancellationToken cancellationToken = default(CancellationToken));

        IGenericRepository<T> GetRepository<T>() where T: class;

        void DoInTransaction(Action<IUnitOfWork> action, IsolationLevel level = IsolationLevel.ReadCommitted);

        void Detach<T>(T entity) where T : class;

        int SaveChanges();
    }
}
