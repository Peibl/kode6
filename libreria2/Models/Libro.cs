using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace libreria.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Titulo { get; set; }

        public int AnioPublicado { get; set; }
        [Required]
        public int Stock { get; set; }
        [ForeignKey("Editorial")]
        public int? EditorialId { get; set; }
        public Editorial Editorial { get; set; }
        // (clave foránea con género)
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public ICollection<LibroAutor> Autores { get; set; }





    }
}
