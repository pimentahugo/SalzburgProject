using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SalzburgProject.Interface;
using SalzburgProject.Models;
using SalzburgProject.Repository;
using System.Diagnostics;
using System.Globalization;

namespace SalzburgProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustoRepository dbContext;
        private readonly IFolgaRepository _folgaRepository;

        public HomeController(ICustoRepository custoRepository, IFolgaRepository folgaRepository)
        {
            dbContext = custoRepository;
            _folgaRepository = folgaRepository;
        }

        public async Task<IActionResult> Index()
        {
            // Relatório de Custos por Tipo
            IEnumerable<Custo> custo = await dbContext.GetAll();

            var custosPorTipo = custo
                .GroupBy(c => c.TipoCusto)
                .Select(g => new
                {
                    TipoCusto = g.Key.ToString(),
                    Total = g.Sum(c => c.Valor)
                })
                .ToList();

            var labelsCustosPorTipo = custosPorTipo.Select(c => c.TipoCusto).ToArray();
            var dataCustosPorTipo = custosPorTipo.Select(c => c.Total).ToArray();

            // Relatório de Custos por Mês
            var custosPorMes = custo
                .GroupBy(c => c.Data.Month)
                .Select(g => new
                {
                    Mes = g.Key,
                    Total = g.Sum(c => c.Valor)
                })
                .OrderBy(g => g.Mes)
                .ToList();

            var labelsCustosPorMes = custosPorMes.Select(c => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(c.Mes)).ToArray();
            var dataCustosPorMes = custosPorMes.Select(c => c.Total).ToArray();

            ViewBag.ChartLabelsCustosPorTipo = labelsCustosPorTipo;
            ViewBag.ChartDataCustosPorTipo = dataCustosPorTipo;
            ViewBag.ChartLabelsCustosPorMes = labelsCustosPorMes;
            ViewBag.ChartDataCustosPorMes = dataCustosPorMes;

            IEnumerable<Folga> folgas = await _folgaRepository.GetAll();
            var folgaPorDiaSemana = folgas
                .GroupBy(p => p.DataFolga.DayOfWeek)
                .Select(group => new
                {
                    DiaDaSemana = group.Key.ToString(),
                    TotalFolgas = group.Count()
                })
                .OrderBy(group => group.DiaDaSemana)
                .ToList();

            ViewBag.FolgasPorDiaSemana = JsonConvert.SerializeObject(folgaPorDiaSemana);

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}