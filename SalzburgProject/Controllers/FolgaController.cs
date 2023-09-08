using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;
using SalzburgProject.Repository;

namespace SalzburgProject.Controllers
{
    public class FolgaController : Controller
    {
        private readonly IFolgaRepository _folgaRepository;
        private readonly IColaboradorRepository _colaboradorRepository;

        public FolgaController(IFolgaRepository folgaRepository, IColaboradorRepository colaboradorRepository) 
        { 
            _folgaRepository = folgaRepository;
            _colaboradorRepository = colaboradorRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Folga> folgas = await _folgaRepository.GetAll();
            return View(folgas);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<Colaborador> colaboradores = await _colaboradorRepository.GetAll();

            // Cria a SelectList para a ViewBag, usando a lista de colaboradores
            ViewBag.ColaboradorList = new SelectList(colaboradores, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Folga folga)
        {
            if (ModelState.IsValid)
            {
                return View(folga);
            }
            _folgaRepository.Add(folga);
            return RedirectToAction("Index");
        }
    }
}
