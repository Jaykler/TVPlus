using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVPlus.Application.Interfaces.Services;
using TVPlus.Application.Models.Genero;

namespace TVPlus.Web.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroService _generoService;
        public GeneroController( IGeneroService generoService)
        {
            _generoService = generoService;
            
        }

        // GET: Genero
        public async Task<IActionResult> Index()
        {
            return View(await _generoService.GetAllModel());
        }

        // GET: Genero/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: Genero/Create
        public IActionResult Create()
        {

            return View("SaveGeneroModel", new SaveGeneroModel());
        }

        // POST: Genero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaveGeneroModel sgm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGeneroModel", sgm);
            }
            await _generoService.AddAsync(sgm);
            return RedirectToRoute(new { controller = "Genero", action = "Index"});

        }

        // GET: Genero/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: Genero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Genero/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: Genero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
