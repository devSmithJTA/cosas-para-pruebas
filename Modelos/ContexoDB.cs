﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Modelos
{
    public class ContexoDB : DbContext
    {
        public ContexoDB(DbContextOptions<ContexoDB> options) : base(options) { }
        //public DbSet<Curso> Curso { get; set; }
    }
}
