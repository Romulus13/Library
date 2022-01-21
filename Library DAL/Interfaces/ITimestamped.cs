using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_DAL.Interfaces
{
    internal interface ITimestamped
    {
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
