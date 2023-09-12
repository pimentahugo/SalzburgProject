using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalzburgProject.Data;
using SalzburgProject.Interface;
using SalzburgProject.Models;
using SalzburgProject.Models.Enum;

namespace SalzburgProject.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IChavePixRepository _chavepixRepository;
        private readonly IFolgaRepository _folgaRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository, IChavePixRepository chavePixRepository, IFolgaRepository folgaRepository)
        {
            _colaboradorRepository = colaboradorRepository;
            _chavepixRepository = chavePixRepository;
            _folgaRepository = folgaRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Colaborador> colaboradores = await _colaboradorRepository.GetAll();
            return View(colaboradores);
        }

        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                var colaborador = await _colaboradorRepository.GetByIdAsync(id);
                if (colaborador == null)
                {
                    TempData["Error"] = "Colaborador não encontrado em nossa base de dados.";
                    return RedirectToAction("Index");

                }
                ViewBag.FolgasColaborador = await _folgaRepository.GetAllFolgasByColaborador(id);
                ViewBag.ChavesPix = await _chavepixRepository.GetAllByColaborador(id);

                return View(colaborador);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Não foi possível carregar as informações do colaborador: " + e.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        [Bind("Id,Name,CPF,Telephone, Type, ChavesPix")] SalzburgProject.Models.Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return View(colaborador);
            }

            if (_colaboradorRepository.CPFExist(colaborador.CPF))
            {
                ModelState.AddModelError("CPF", "CPF informado já está cadastrado em nosso banco de dados.");
                return View(colaborador);
            }

            colaborador.Status = ColaboradorStatus.Ativo; //criar sempre como ativo

            try
            {
                await _colaboradorRepository.Add(colaborador);
                //Add ChavePix to Colaborador
                if (colaborador.ChavesPix != null)
                {
                    foreach (var item in colaborador.ChavesPix)
                    {
                        await _chavepixRepository.Add(item);
                    }
                }

                await _colaboradorRepository.Commit();
                TempData["Success"] = $"Colaborador {colaborador.Name} criado com sucesso!";
            }
            catch (Exception e)
            {
                TempData["Error"] = "Ocorreu um erro durante a criação: " + e.Message;
                await _colaboradorRepository.Rollback();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(int id, Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return View(colaborador);
            }
            _colaboradorRepository.Update(colaborador);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Detail(Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return View(colaborador);
            }
            try
            {
                _colaboradorRepository.Update(colaborador);
                await _colaboradorRepository.Commit();
                TempData["Success"] = "Colaborador atualizado com sucesso!";
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro durante a atualização: " + e.Message);
                await _colaboradorRepository.Rollback();
                return View(colaborador);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateKeyPix(
        [Bind("Id,Name,CPF,Telephone, Type, ChavesPix")] Colaborador colaborador)
        {
            if (colaborador == null)
            {
                return View(colaborador);
            }

            if (!ModelState.IsValid)
            {
                return View(colaborador);
            }

            try
            {
                //Add ChavePix to Colaborador
                if (colaborador.ChavesPix != null)
                {
                    foreach (var item in colaborador.ChavesPix)
                    {
                        var chavePix = new ChavePix
                        {
                            Type = item.Type,
                            KeyPix = item.KeyPix,
                            ColaboradorId = colaborador.Id,
                            //Colaborador = colaborador
                        };
                        await _chavepixRepository.Add(chavePix);
                    }
                }

                await _chavepixRepository.Commit();
                TempData["Success"] = $"Colaborador {colaborador.Name} criado com sucesso!";
            }
            catch (Exception e)
            {
                TempData["Error"] = "Ocorreu um erro durante a criação: " + e.Message;
                await _chavepixRepository.Rollback();
                return RedirectToAction("Index");
            }

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

        public IActionResult Error(ErrorViewModel error)
        {
            return View(error);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteKeyPix(int id)
        {
            var chavePix = await _chavepixRepository.GetByIdAsync(id);
            try
            {
                if (chavePix != null)
                {
                    _chavepixRepository.Delete(chavePix);
                    await _chavepixRepository.Commit();
                    TempData["Success"] = "Chave Pix excluída com sucesso!";
                }
                else
                {
                    TempData["Error"] = "Chave Pix não encontrada.";
                }
            }
            catch (Exception e)
            {
                TempData["Error"] = "Ocorreu um erro durante a criação: " + e.Message;
                await _colaboradorRepository.Rollback();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Detail", new { id = chavePix.ColaboradorId });

        }

    }
}
