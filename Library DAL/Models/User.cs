using Library_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Models
{
    public class User : ITimestamped
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public DateTime Created { get ; set ; }
        public DateTime? Modified { get; set ; }
        public virtual ICollection<BookRent>? BookRents { get; set; }
        public ICollection<UserContact>? UserContacts { get;  set; }
    }
}
