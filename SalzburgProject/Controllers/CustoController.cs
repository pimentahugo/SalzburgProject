using Microsoft.AspNetCore.Mvc;
using SalzburgProject.Interface;

namespace SalzburgProject.Controllers
{
    public class CustoController : Controller
    {
        private readonly ICustoRepository _custoRepository;

        public CustoController(ICustoRepository custoRepository)
        {
            _custoRepository = custoRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
