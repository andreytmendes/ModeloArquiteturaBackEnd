using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
    }
}
