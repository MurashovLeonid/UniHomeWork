using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHomeWork.Contracts.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class AmountValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not decimal)
            {
                return false;
            }
            return (decimal)value >= 0;
        }

    }
}
