﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHomeWork.Domain.Interfaces;

namespace UniHomeWork.Domain
{
    public class Entity : IAuditable
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

    }
}
