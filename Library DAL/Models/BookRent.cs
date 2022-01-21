using Library_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Models
{
    /// <summary>
    /// Table that keeps book rents to other users
    /// </summary>
    public class BookRent : ITimestamped
    {
        public long Id { get; set; }
        public int UserId { get; set; }

        public long BookId { get; set; }

        public DateTime Borrowed { get; set;}

        public DateTime DueDate { get; set; }
        public DateTime Created { get ; set ; }
        public DateTime? Modified { get ; set ; }
        public virtual Book? Book { get; internal set; }
        public virtual User? User { get; internal set; }
    }
}
