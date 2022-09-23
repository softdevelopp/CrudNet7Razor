using CrudNet7Razor.Datos;
using CrudNet7Razor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7Razor.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Producto> Productos { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Productos = await _contexto.Producto.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            var producto = await _contexto.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _contexto.Producto.Remove(producto);
            await _contexto.SaveChangesAsync();
            Mensaje = "Producto borrado correctamente";
            return RedirectToPage("Index");
        }
    }
}
