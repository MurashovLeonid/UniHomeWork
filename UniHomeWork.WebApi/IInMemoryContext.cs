using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UniHomeWork.Domain;

namespace UniHomeWork.Infrastructure.Interfaces
{
    internal interface IInMemoryContext
    {
        public Task SaveEntityToDb(Entity entity);
    }
}
