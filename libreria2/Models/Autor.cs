using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace libreria.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String Nombre { get; set; }
        [MaxLength(100)]
        public String Apellido { get; set; }
        public ICollection<LibroAutor> Libros { get; set; }
    }
}
