﻿using Microsoft.AspNetCore.Mvc;
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
            var colaborador = await _colaboradorRepository.GetByIdAsync(id);
            ViewBag.FolgasColaborador = await _folgaRepository.GetAllFolgasByColaborador(id);
            if (colaborador == null)
            {
                View("Error");
            }

            return View(colaborador);
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

            _colaboradorRepository.Add(colaborador);
            //Add ChavePix to Colaborador
            foreach (var item in colaborador.ChavesPix)
            {
                item.Id = null;
                _chavepixRepository.Add(item);
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
