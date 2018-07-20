using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMvcDoAlmoco.Interfaces;
using WebMvcDoAlmoco.Models;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Controllers
{
    public class HomeController : Controller
    {
        IEleicaoRepositorio _votacaoRepositorio;
        IVotoRepositorio _votoRepositorio;

        public HomeController(IEleicaoRepositorio votacaoRepositorio, IVotoRepositorio votoRepositorio)
        {
            _votacaoRepositorio = votacaoRepositorio;
            _votoRepositorio = votoRepositorio;
        }


        public IActionResult Index()
        {
            var listaReis = RetornarReisUltimasSemanas();

            return View(listaReis);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private Eleicao RetornarReisUltimasSemanas()
        {
            Eleicao resumo = new Eleicao
            {
                Voto = new List<Voto>()
            };

            var retornaTodos = _votacaoRepositorio.RetornarTodos();


            //foreach (var item in retornaTodos)
            //{
            //    resumo.Id = item.Id;
            //    resumo.Data = ((Eleicao)item).Data;
            //   var votos = _votoRepositorio.RetornarIdEleicao(item.Id);
            //    foreach (var item1 in votos)
            //    {
            //        var v = new Voto { CandidatoId = item1.CandidatoId, Total = item1.Total  };
            //        resumo.Voto.Add(v);
            //    }
            return resumo;
        }
    }
}

