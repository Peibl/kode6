using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace libreria.Models
{
    public class Genero
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public String Titulo { get; set; }
        [MaxLength(50)]
        public String ClaseCss { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
