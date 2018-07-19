using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvcDoAlmoco.Models;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Controllers
{

    public class CandidatoController : Controller
    {
        private ICandidatoRepositorio _candidatoRepositorio;

        public CandidatoController(ICandidatoRepositorio candidatoRepositorio)
        {
            _candidatoRepositorio = candidatoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Candidato candidato)
        {
            try
            {
                if (!ModelState.IsValid)                
                    return View(candidato);              

                _candidatoRepositorio.Adicionar(candidato);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", ex.Message);
                return View(candidato);
            }
                        
            return RedirectToAction("VisualizarCandidatos");


        }

        [Authorize]
        public IActionResult Editar ()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Editar(Candidato candidato)
        {
            return View();
        }

        [Authorize]
        public IActionResult Excluir()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Excluir(Candidato candidato)
        {
            return View();
        }

        [Authorize]        
        public IActionResult VisualizarCandidatos()
        {
            ListarCandidatos();
           return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Listar()
        {
            ListarCandidatos();
            return View();
        }
        
        private void ListarCandidatos()
        {
            var listacandidatos = _candidatoRepositorio.RetornarTodos();
            IList<Candidato> listaModeloCandidato= new List<Candidato>();
            foreach (var item in listacandidatos)
            {
                listaModeloCandidato.Add((Candidato)item);
            }       

            ViewData["ListaCandidatos"] = listaModeloCandidato;           
        }

    }
}