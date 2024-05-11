using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHomeWork.Domain.Interfaces
{
    public interface IAuditable
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
