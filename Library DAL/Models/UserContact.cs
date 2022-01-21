using Library_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Models
{
    public class UserContact
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 

        public string? Value { get; set; }
        public ContactType Type { get; set; }
        public User? User { get;  set; }
    }
}
