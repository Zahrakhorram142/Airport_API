﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Dtos;

public record RegisterDto(string Username,string Password,string FirstName,string LastName);

