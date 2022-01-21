using Library_DAL.Configurations;
using Library_DAL.Interfaces;
using Library_DAL.Models;
using Library_DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Library_DAL
{
    public class LibraryDbContext : DbContext, IUnitOfWork
    {

        private readonly ILogger _logger;

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _logger = loggerFactory.CreateLogger("logs");
        }

        public IUserRepository Users => new UserRepository(this, _logger);
        public IGenericRepository<UserContact> UserContacts => GetRepository<UserContact>();
        public IGenericRepository<Book> Books => GetRepository<Book>();
        public IBookRentRepository BookRents => new BookRentRepository(this, _logger);
        public IGenericRepository<BookInventoryItem> BookInventoryItems => GetRepository<BookInventoryItem>();

        


        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookRentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookInventoryItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserContactEntityTypeConfiguration());

            modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName ="Ivan" , LastName = "Horvat" , BirthDate = new DateTime(1987,2,3) },
                                                new User { Id = 2, FirstName = "Marko", LastName = "Ban", BirthDate = new DateTime(2001, 6, 23) },
                                                new User { Id = 3, FirstName = "Iva", LastName = "Kralj", BirthDate = new DateTime(1993, 1, 11) });

            modelBuilder.Entity<UserContact>().HasData(new UserContact {Id = 1, Value = "+9877412111", Type = Enums.ContactType.Mobile, UserId = 1 },
                                                new UserContact { Id = 2, Value = "iva.kralj@aol.com", Type = Enums.ContactType.Email, UserId = 3 }
                                                );

            modelBuilder.Entity<Book>().HasData(new Book {Id = 1, ISBN = "0618002227", Authors = "J.R.R. Tolkien" , ReleaseDate = new DateTime(1954,7,29), SerialNumber = Guid.NewGuid().ToString(), PrintDate = new DateTime(2008,12,2), Title = "The Fellowship of the Ring" },
                                              new Book {Id = 2, ISBN = "0618002113", Authors = "J.R.R. Tolkien", ReleaseDate = new DateTime(1954, 7, 29), SerialNumber = Guid.NewGuid().ToString(), PrintDate = new DateTime(2001, 2, 21), Title = "The Fellowship of the Ring" },
                                              new Book {Id = 3, ISBN = "09568879111", Authors = "Edgar Rice Burroughs", ReleaseDate = new DateTime(1917, 1, 1), SerialNumber = Guid.NewGuid().ToString(), PrintDate = new DateTime(2011, 11, 13), Title = "A Princess of Mars" }
                                              );
            modelBuilder.Entity<BookRent>().HasData(new BookRent { Id = 1, BookId =1, UserId= 1, Borrowed = new DateTime(2021,1,1), DueDate = new DateTime(2021,12,1) },
                                                new BookRent { Id = 2, BookId = 3, UserId = 3, Borrowed = new DateTime(2021, 12, 31), DueDate = new DateTime(2022, 2, 28) }
                                             ,
                                              new BookRent { Id = 3, BookId = 3, UserId = 2, Borrowed = new DateTime(2021, 06, 25), DueDate = new DateTime(2021, 12, 25) }
                                              );
            modelBuilder.Entity<TopOverdueUsers>(sd =>
            {
                sd.HasNoKey().ToView(null);
            });
        }
        #endregion


        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            var returnInt = await SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return returnInt;
        }


        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(this, _logger);
        }

        public void DoInTransaction(Action<IUnitOfWork> action, IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            using (var transaction = Database.BeginTransaction(level))
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
        }

        public void Detach<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Detached;
        }
    }
}