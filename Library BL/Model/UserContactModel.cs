using Library_BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_BL.Model
{
    public class UserContactModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Value { get; set; }
        public ContactType Type { get; set; }
    }
}
