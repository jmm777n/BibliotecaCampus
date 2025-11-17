using BibliotecaCampus.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaCampus.Data
{
    public class LibroRepository : ILibroRepository
    {
        private static readonly List<Libro> _libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            _libros.Add(libro);
        }

        public IEnumerable<Libro> ObtenerLibros()
        {
            return _libros;
        }

        public bool ExisteCodigoInterno(string codigoInterno)
        {
            return _libros.Any(l => l.CodigoInterno == codigoInterno);
        }
    }
}
