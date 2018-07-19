using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMvcDoAlmoco.Models;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Controllers
{
    public class HomeController : Controller
    {
        IVotacaoRepositorio _votacaoRepositorio;

        public HomeController(IVotacaoRepositorio votacaoRepositorio)
        {
            _votacaoRepositorio = votacaoRepositorio;
        }
              
      
        public IActionResult Index()
        {
            var listaReis =  RetornarReisUltimasSemanas();

            return View();
        }
               

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IList<Votacao> RetornarReisUltimasSemanas()
        {
            var retornaTodos = _votacaoRepositorio.RetornarTodos();
            return null;
        }



    }
}
