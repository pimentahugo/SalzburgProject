using Microsoft.AspNetCore.Mvc;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;
using SalzburgProject.Repository;

namespace SalzburgProject.Controllers
{
    public class FolgaController : Controller
    {
        private readonly IFolgaRepository _folgaRepository;

        public FolgaController(IFolgaRepository folgaRepository) 
        { 
            _folgaRepository = folgaRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Folga> folgas = await _folgaRepository.GetAll();
            return View(folgas);
        }
    }
}
