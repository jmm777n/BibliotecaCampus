using System;
using BibliotecaCampus.Data;
using BibliotecaCampus.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaCampus.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroRepository _repo;

        public LibroController(ILibroRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var libros = _repo.ObtenerLibros();
            return View(libros);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View(new Libro());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Libro libro)
        {
            if (libro.AnioPublicacion.HasValue && libro.AnioPublicacion.Value > DateTime.Now.Year)
            {
                ModelState.AddModelError(nameof(Libro.AnioPublicacion), "El año de publicación no puede ser un año futuro.");
            }

            if (string.IsNullOrWhiteSpace(libro.Categoria) || libro.Categoria == "Seleccione...")
            {
                ModelState.AddModelError(nameof(Libro.Categoria), "Debe seleccionar una categoría.");
            }

            if (!string.IsNullOrWhiteSpace(libro.CodigoInterno) && _repo.ExisteCodigoInterno(libro.CodigoInterno))
            {
                ModelState.AddModelError(nameof(Libro.CodigoInterno), "El código interno ya existe. Debe ser único.");
            }

            if (!ModelState.IsValid)
            {
                return View(libro);
            }

            _repo.AgregarLibro(libro);
            TempData["Mensaje"] = "Libro registrado correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}
