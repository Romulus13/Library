using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Models
{
    public class TopOverdueUsers
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName  { get; set; }

        public int TotalDaysOverdue { get; set; }
    }
}
