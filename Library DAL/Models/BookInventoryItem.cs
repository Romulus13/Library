using Library_DAL.Enums;
using Library_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Models
{
    public class BookInventoryItem : ITimestamped
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public BookStatus? Status { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime Created { get ; set; }
        public DateTime? Modified { get ; set ; }
        public Book? Book { get; internal set; }
    }
}
