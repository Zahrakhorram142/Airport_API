using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Contracts
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public int Code { get; set; }

    }

}
