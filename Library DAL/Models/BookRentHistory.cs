using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Models
{
    public class BookRentHistory
    {

        public BookRent BookRent { get; set; }
        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public BookRentHistory(BookRent bookrent,DateTime validFrom, DateTime validTo)
        {
            BookRent = bookrent;
            ValidFrom = validFrom;
            ValidTo = validTo;
        }

    }
}
