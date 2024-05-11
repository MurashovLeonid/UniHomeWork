using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHomeWork.Contracts.ValidationAttributes;

namespace UniHomeWork.Contracts
{
    public class CreateEntityDto
    {
        [Required]
        [AmountValidation]
        public decimal Amount { get; set; }
    }
}
