using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHomeWork.Contracts.ErrorDtos
{
    public class NotFoundDto
    {
        public string Notification { get; }
        public NotFoundDto(Guid id)
        {
            Notification = $"There is no entity with id {id}";
        }
    }
}
