using Library_DAL.Interfaces;
using Library_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LibraryDbContext context, ILogger logger) : base(context, logger) { }

        public async Task<List<TopOverdueUsers>> GetMostOverdueUsers()
        {
            var topOverDueUsers = await context.Set<TopOverdueUsers>().FromSqlRaw($@"SELECT DISTINCT innerQuery.FirstName, innerQuery.LastName, innerQuery.Id AS UserId,innerQuery.TotalOverdue As TotalDaysOverdue FROM
                                                                 (
                                                                      SELECT
                                                                         us.FirstName, us.LastName, us.Id
                                                                        , SUM(DATEDIFF(dd, br.DueDate, GETUTCDATE())) OVER(PARTITION BY br.UserId) AS TotalOverdue
                                                                      FROM [Library].[dbo].[BookRents] br
                                                                            INNER JOIN[Library].[dbo].[Users] us
                                                                            ON us.Id = br.UserId
                                                                            WHERE PeriodEnd > GETUTCDATE()
                                                                   ) as innerQuery
                                                                WHERE TotalOverdue > 0
                                                                ORDER BY TotalOverdue DESC").ToListAsync();

            return topOverDueUsers;
        }
    }
}
