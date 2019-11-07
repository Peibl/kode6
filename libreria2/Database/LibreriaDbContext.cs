using libreria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libreria.Database
{
    public class LibreriaDbContext: DbContext
    {
        public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options): base(options) {
        }
            
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<LibroAutor> AutoresLibro { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
