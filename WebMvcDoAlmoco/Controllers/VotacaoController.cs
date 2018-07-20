using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMvcDoAlmoco.Interfaces;
using WebMvcDoAlmoco.Models;
using WebMvcDoAlmoco.Models.VotacaoViewModel;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Controllers
{
    public class VotacaoController : Controller
    {
        
        private IEleicaoRepositorio  _votacaoRepositorio;
        private ICandidatoRepositorio _candidatoRepositorio;
        private IVotoRepositorio _votoRepositorio;

        public VotacaoController(IEleicaoRepositorio votacaoRepositorio, ICandidatoRepositorio candidatoRepositorio, IVotoRepositorio votoRepositorio)
        {            
            _votacaoRepositorio = votacaoRepositorio;
            _candidatoRepositorio = candidatoRepositorio;
            _votoRepositorio = votoRepositorio;
        }

        public IActionResult Index()
        {
            var listacandidatovoto = new List<CandidatoViewModel>();
            var eleicao = new EleicaoViewModel { CandidatoVotos = ListarCandidatos(), Data = DateTime.Today };
            return View(eleicao);
        }

        [HttpPost]
        public ActionResult Index(IFormCollection frm)
        {
            try
            {
                if (!HabilitaVotacao())
                {
                    ViewBag.Horario = "Horário de votação encerrado!";
                    return View();
                }
                if (ModelState.IsValid)
                {
                    foreach (var item in frm)
                    {
                        if (item.Key == "VotoId")
                        {
                            Candidato candidato = null;
                            var retornaVotacao = _votacaoRepositorio.Retornar(DateTime.Today);
                            if (retornaVotacao == null)
                            {
                               
                                //Virar um metodo privado
                                var id = Convert.ToInt32(item.Value);
                                candidato = _candidatoRepositorio.RetornarId(id);                               
                                var voto = new Voto { Candidato = candidato, Total = 1 };
                                List<Voto> list = new List<Voto>{ voto};
                                var lvoto = list;

                                var eleicao = new Eleicao { Data = DateTime.Today, Voto = list };

                                _votacaoRepositorio.Adicionar(eleicao);
                            }
                            else
                            {
                                var id = Convert.ToInt32(item.Value);
                                candidato = _candidatoRepositorio.RetornarId(id);

                                foreach (var itemvoto in retornaVotacao.Voto)
                                {
                                    if (itemvoto.CandidatoId == id)
                                    {
                                        itemvoto.Total++;
                                        _votacaoRepositorio.Atualizar(retornaVotacao);
                                        return RedirectToAction("Index", "Home");
                                    }
                                }                                
                                var primeirovoto = new Voto { Candidato = candidato, Total = 1 };
                                List<Voto> list = new List<Voto> { primeirovoto };
                                retornaVotacao.Voto.Add(primeirovoto);
                                _votacaoRepositorio.Atualizar(retornaVotacao);
                            }
                        }
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {               
                return View(ModelState);
            }
          
        }
       
        private IList<Candidato> ListarCandidatos()
        {
            var listacandidatos = _candidatoRepositorio.RetornarTodos();
            IList<Candidato> listaModeloCandidato = new List<Candidato>();
            foreach (var item in listacandidatos)
            {
                listaModeloCandidato.Add((Candidato)item);
            }

            ViewData["ListaCandidatos"] = listaModeloCandidato;
            return listaModeloCandidato;
        }
      
        private bool HabilitaVotacao()
        {

            var horarioinicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            var horafinal = new  DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 2, 0);
            var resultadoinicial = DateTime.Compare(horarioinicial, DateTime.Now);
            var resultadofinal = DateTime.Compare(horafinal, DateTime.Now);
                                     
            if (resultadoinicial < 0 && resultadofinal <0)           
            {              
                return false;
            }
            return true;
        }
           
    }        

}
