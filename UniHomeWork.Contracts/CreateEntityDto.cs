using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHomeWork.Contracts
{
    public class CreateEntityDto
    {
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }

    }
}
