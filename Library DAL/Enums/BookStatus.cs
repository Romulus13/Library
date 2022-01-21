using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Enums
{
    public enum BookStatus
    {
        Available = 0,
        Borrowed = 1,
        Returned = 2,
        Lost = 3,
        Damaged = 4
    }
}
