using mf_dev_backend_e2_2024_ads.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_dev_backend_e2_2024_ads.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

       public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();

            return View(dados);
        }

        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid) 
            { 
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
