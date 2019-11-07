using System.ComponentModel.DataAnnotations.Schema;

namespace libreria.Models
{
    public class LibroAutor
    {
        public int Id { get; set; }
        [ForeignKey("Author")]
        public int AutorId;
        public Autor Autor;
        [ForeignKey("Libro")]
        public int LibroId;
        public Libro Libro;
    }
}