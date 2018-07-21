using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMvcDoAlmoco.Models;
using WebMvcDoAlmoco.Models.VotacaoViewModel;
using WebMvcDoAlmoco.Services;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Controllers
{

    public class CandidatoController : Controller
    {
        private ICandidatoRepositorio _candidatoRepositorio;
        private  IHostingEnvironment _environment;
        private IEmailSender _emailSender;

        public CandidatoController(ICandidatoRepositorio candidatoRepositorio, IHostingEnvironment IHostingEnvironment, IEmailSender emailSender)
        {
            _candidatoRepositorio = candidatoRepositorio;
            _environment = IHostingEnvironment;
            _emailSender = emailSender;
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
                {                   
                    return View(candidato);
                }

                //Todo * Refatorar 
                
                var fileCaminho = Path.GetTempFileName();
                var novoNomeArquivo = string.Empty;
                var nomeArquivo = string.Empty;
                string PathDB = string.Empty;


                var files = HttpContext.Request.Form.Files;  
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {                        
                        nomeArquivo = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');                      
                        var nomeExclusivoArquivo = Convert.ToString(Guid.NewGuid());                       
                        var extensaoArquivo = Path.GetExtension(nomeArquivo);
                       
                        novoNomeArquivo = nomeExclusivoArquivo + extensaoArquivo;
                        
                        nomeArquivo = Path.Combine(_environment.WebRootPath, "FotoCandidatos") + $@"\{novoNomeArquivo}";

                        using (FileStream fs = System.IO.File.Create(nomeArquivo))                      
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                        candidato.Foto = "../FotoCandidatos/" + nomeExclusivoArquivo + extensaoArquivo;
                    }
                }  
                //candidato.Email = User.Identity.Name;
                _candidatoRepositorio.Adicionar(candidato);
                _emailSender.SendEmailAsync(candidato.Email, "Cadastro restaurante", "Parabéns, cadastro efetuado com sucesso!");
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
            IList<CandidatoViewModel> listaModeloCandidato= new List<CandidatoViewModel>();
            
            foreach (var item in listacandidatos)
            {
                var cand = (Candidato)item;
                CandidatoViewModel cvm = new CandidatoViewModel();

                cvm.Candidato = cand;
                if (cand.Foto != null)
                {                  
                    listaModeloCandidato.Add(cvm);
                }
                else
                {
                    cvm.Imagem = null;
                    listaModeloCandidato.Add(cvm);
                }
                
            }       

            ViewData["ListaCandidatos"] = listaModeloCandidato;           
        }
        
    }

    public static class LoadImage
    {

        public static byte[] GetPictureData(string imagePath)
        {
            FileStream fs = new FileStream(imagePath, FileMode.Open);
            byte[] byteData = new byte[fs.Length];
            fs.Read(byteData, 0, byteData.Length);
            fs.Close();
            return byteData;
        }
    }
    public static class FileStrem
    {
        /// <summary>
        /// get absolute path
        /// </summary>
        /// <param name="relativepath">"TextFile.txt"</param>
        /// <returns></returns>
        public static string GetFilePath(string relativepath)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), relativepath);
        }
    }

}