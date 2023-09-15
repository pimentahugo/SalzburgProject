using Microsoft.AspNetCore.Mvc;
using SalzburgProject.Interface;
using SalzburgProject.Models;
using SalzburgProject.Models.Enum;
using SalzburgProject.Repository;
using System.Linq;

namespace SalzburgProject.Controllers
{
    public class CustoController : Controller
    {
        private readonly ICustoRepository _custoRepository;
        private readonly IFolgaRepository _folgaRepository;

        public CustoController(ICustoRepository custoRepository, IFolgaRepository folgaRepository)
        {
            _custoRepository = custoRepository;
            _folgaRepository = folgaRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Custo> custos = await _custoRepository.GetAll();
            var custosPorAno = custos.OrderBy(custo => custo.Data.Month).GroupBy(custo => custo.Data.Year)
                                     .Select(groupAno => new
                                     {
                                         Ano = groupAno.Key,
                                         Meses = groupAno.GroupBy(custo => custo.Data.Month)
                                     });

            return View(custosPorAno);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Custo custo)
        {
            if (!ModelState.IsValid)
            {
                return View(custo);
            }

            try
            {
                if (custo.Parcelado)
                {
                    for (int aux = 0; aux < custo.QtdParcelamento; aux++)
                    {
                        Custo novaParcela = new Custo
                        {
                            Name = custo.Name,
                            TipoCusto = custo.TipoCusto,
                            TipoPagamento = custo.TipoPagamento,
                            QtdParcelamento = custo.QtdParcelamento,
                            Data = custo.Data.AddMonths(aux),
                            Valor = custo.Valor,
                            Parcelado = true,
                            ParcelaAtual = $"{aux + 1}/{custo.QtdParcelamento}"
                        };
                        await _custoRepository.Add(novaParcela);
                    }
                }
                else
                {
                    await _custoRepository.Add(custo);
                }
                await _custoRepository.Commit();
                TempData["Success"] = $"Custo {custo.Name} criado com sucesso!";
            }
            catch (Exception e)
            {
                TempData["Error"] = "Ocorreu um erro durante a criação: " + e.Message;
                await _custoRepository.Rollback();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var custo = await _custoRepository.GetByIdAsync(id);
                _custoRepository.Delete(custo);
                _custoRepository.Commit();
                TempData["Success"] = "Você excluiu " + custo.Name + " com sucesso.";
                return RedirectToAction("Index");
            } catch(Exception e)
            {
                TempData["Error"] = "Erro ao excluir custo: " + e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
