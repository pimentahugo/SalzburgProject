using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;

namespace SalzburgProject.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Colaborador> colaboradores = await _colaboradorRepository.GetAll();
            return View(colaboradores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                return View(colaborador);
            }
            _colaboradorRepository.Add(colaborador);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var colaborador = await _colaboradorRepository.GetByIdAsync(id);

            if(colaborador == null)
            {
                View("Error");
            }

            return View(colaborador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                return View(colaborador);
            }
            _colaboradorRepository.Update(colaborador);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var colaborador = await _colaboradorRepository.GetByIdAsync(id);

            if (colaborador == null)
            {
                View("Error");
            }

            return View(colaborador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            _colaboradorRepository.Delete(colaborador);
            return RedirectToAction("Index");
        }

    }
}
