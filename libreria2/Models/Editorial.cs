using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace libreria.Models
{
    public class Editorial
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String nombre { get; set; }
        public ICollection<Libro> libros { get; set; }
}
}
