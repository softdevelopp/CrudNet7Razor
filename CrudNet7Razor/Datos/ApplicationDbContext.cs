﻿using CrudNet7Razor.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7Razor.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        //Poner aquí los modelos
        public DbSet<Producto> Producto { get; set; }
    }
}
