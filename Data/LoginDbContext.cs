﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class LoginDbContext:IdentityDbContext
    {
        public LoginDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
