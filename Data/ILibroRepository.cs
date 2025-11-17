using BibliotecaCampus.Models;
using System.Collections.Generic;

namespace BibliotecaCampus.Data
{
    public interface ILibroRepository
    {
        void AgregarLibro(Libro libro);
        IEnumerable<Libro> ObtenerLibros();
        bool ExisteCodigoInterno(string codigoInterno);
    }
}
