﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Domain.Contracts;

public interface IBaseSeeder<T>
{
    IEnumerable<T> GetSeedData();
}
