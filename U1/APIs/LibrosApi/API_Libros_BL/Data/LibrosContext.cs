using API_Libros_BL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Libros_BL.Data
{
    
    public class LibrosContext : DbContext
    {
        private static LibrosContext librosContext = null;
        public LibrosContext() 
            : base("LibrosConnexion")
        {
            
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }

        //patron singleton - instanciando una sola vez
        public static LibrosContext Create()
        {
            return new LibrosContext();
        }
    }
}
