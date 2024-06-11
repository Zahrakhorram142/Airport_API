using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Contracts;

public interface IAuditable
{
    public int UserId { get; set; }    
    public DateTime UpdateAt { get; set; }
}
