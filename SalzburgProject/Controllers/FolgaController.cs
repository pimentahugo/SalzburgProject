using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;
using SalzburgProject.Models.Enum;
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
            //IEnumerable<FolgaViewModel> folgas = (await _folgaRepository.GetAll())
            //                                   .Select(folga => new FolgaViewModel(folga));
            IEnumerable<Folga> folgas = (await _folgaRepository.GetAll()).OrderBy(p => p.DataFolga);
            return View(folgas);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<Colaborador> colaboradores = await _colaboradorRepository.GetAll();

            // Cria a SelectList para a ViewBag, usando a lista de colaboradores
            ViewBag.ColaboradorList = new SelectList(colaboradores.Where(p => p.Status == ColaboradorStatus.Ativo), "Id", "Name");

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
            try
            {
                _folgaRepository.Add(folga);
                _folgaRepository.Commit();
                TempData["Success"] = "Folga criada para o colaborador com sucesso.";
            } catch(Exception e)
            {
                TempData["Error"] = e.Message;
                return View(folga);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var folga = await _folgaRepository.GetByIdAsync(id);
            try
            {
                if (folga != null)
                {
                    _folgaRepository.Delete(folga);
                    await _folgaRepository.Commit();
                    TempData["Success"] = "Folga excluída com sucesso!";
                }
                else
                {
                    TempData["Error"] = "Folga não encontrada.";
                }
            }
            catch (Exception e)
            {
                TempData["Error"] = "Ocorreu um erro durante o processo: " + e.Message;
                await _folgaRepository.Rollback();
            }

            return RedirectToAction("Index");

        }
    }
}
