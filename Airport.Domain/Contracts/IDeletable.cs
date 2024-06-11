using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Contracts;

public interface IDeletable
{
    public int DeleteByUserId { get; set; }
    public DateTime DeletedAt { get; set; }
}
