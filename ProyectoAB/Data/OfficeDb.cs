﻿using Microsoft.EntityFrameworkCore;
using ProyectoAB.Models;

namespace ProyectoAB.Data
{
    public class OfficeDb: DbContext
    {
        public OfficeDb(DbContextOptions<OfficeDb> options): base(options)
        {
            
        }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Estado> Estados => Set<Estado>();

        public DbSet<Colaborador> Colaboradores => Set<Colaborador>();
    }
}
