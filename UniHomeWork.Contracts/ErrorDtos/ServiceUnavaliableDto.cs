using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHomeWork.Contracts.ErrorDtos
{
    public class ServiceUnavaliableDto
    {
        public ServiceUnavaliableDto()
        {
            Notification = "The service is currently unavaliable, please try again later";
        }
        public string Notification { get; set; }
    }
}
