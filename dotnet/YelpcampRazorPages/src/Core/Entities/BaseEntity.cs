using System;
using System.Collections.Generic;
using System.Text;

namespace YelpcampRazorPages.Core.Entities
{
    public abstract class BaseEntity
    {
        public virtual int ID { get; protected set; }
    }
}
