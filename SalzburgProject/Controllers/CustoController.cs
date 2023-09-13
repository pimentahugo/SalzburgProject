using Microsoft.AspNetCore.Mvc;
using SalzburgProject.Interface;
using SalzburgProject.Models;

namespace SalzburgProject.Controllers
{
    public class CustoController : Controller
    {
        private readonly ICustoRepository _custoRepository;

        public CustoController(ICustoRepository custoRepository)
        {
            _custoRepository = custoRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Custo> custos = await _custoRepository.GetAll();
            return View(custos);
        }
    }
}
