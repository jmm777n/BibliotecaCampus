using System.ComponentModel.DataAnnotations;

namespace BibliotecaCampus.Models
{
    public class Libro
    {
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El título debe tener al menos 3 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El autor es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El autor debe tener al menos 3 caracteres.")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public string Categoria { get; set; } = string.Empty;

        [Display(Name = "Año de publicación")]
        [Required(ErrorMessage = "El año de publicación es obligatorio.")]
        [Range(1900, 2100, ErrorMessage = "El año de publicación debe estar entre 1900 y el año actual.")]
        public int? AnioPublicacion { get; set; }

        [Display(Name = "Número de páginas")]
        [Required(ErrorMessage = "El número de páginas es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de páginas debe ser mayor que 0.")]
        public int? NumeroPaginas { get; set; }

        [Display(Name = "Código interno")]
        [Required(ErrorMessage = "El código interno es obligatorio.")]
        [RegularExpression(@"^LIB-\d{3}$", ErrorMessage = "El código interno debe tener el formato LIB-### (ej. LIB-001).")]
        public string CodigoInterno { get; set; } = string.Empty;

        [Required(ErrorMessage = "Se debe indicar si el libro está disponible.")]
        public bool? Disponible { get; set; }
    }
}
