using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WebMvcDoAlmoco;
using WebMvcDoAlmoco.Models;
using WebMvcDoAlmoco.Repositorio;
using WebMvcReiDoAlmoco.Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class UtRepositorio
    {

        #region Atributos
        private string connectionstring = "Data Source = LAPTOP-QSD1P64U; Initial Catalog = ReiDoAlmoco; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        private Mock<IConfigurationSection> configurationSectionStub;
        Mock<IConfiguration> configurationStub;
        private IServiceCollection services;
        private ICandidatoRepositorio candidatoRepositorio;
        private IVotacaoRepositorio votacaoRepositorio;
        private ServiceProvider ServiceProvider;

        private Candidato candidato;
        private Candidato candidato1;
        private Candidato candidato2;

        private VotoCandidato voto1;
        private VotoCandidato voto2;

        private IList<BaseModel> listaCandidatos;
        #endregion
        
        #region Métodos Privados
        private ICandidatoRepositorio RetornarCandidatoRepositorio()
        {
            return ServiceProvider.GetService<ICandidatoRepositorio>();
        }

        private IVotacaoRepositorio RetornarVotacaoRepositorio()
        {
            return ServiceProvider.GetService<IVotacaoRepositorio>();
        }

        private void CaregaDadosParaTeste()
        {
            candidato = new Candidato { Email = "eoalcantara@gmail.com", Nome = "Eduardo Alcantara" };
            candidatoRepositorio = RetornarCandidatoRepositorio();
            candidatoRepositorio.Adicionar(candidato);

            candidato1 = new Candidato { Email = "eoalcantara@gmail.com", Nome = "Eduardo Alcantara" };
            candidato2 = new Candidato { Email = "regina@gmail.com", Nome = "Regina Alcantara" };
            voto1 = new VotoCandidato { Candidato = candidato1, Voto = 1 };
            voto2 = new VotoCandidato { Candidato = candidato2, Voto = 1 };

            var listacandidatos = new List<VotoCandidato>
            {
                voto1,
                voto2
            };

            var votacao = new Votacao { Data = DateTime.Now, ListaCandidato = listacandidatos, TotalVoto = listacandidatos.Count };

            votacaoRepositorio = RetornarVotacaoRepositorio();
            votacaoRepositorio.Adicionar(votacao);

        }
        #endregion

        #region Inicializacao

        [TestInitialize]
        public void SetUp()
        {           

            configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(c => c["Default"]).Returns(connectionstring);
            configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection("ConnectionStrings")).Returns(configurationSectionStub.Object);

            services = new ServiceCollection();
            services.AddTransient<ICandidatoRepositorio, CandidatoRepositorio>();
            services.AddTransient<IVotacaoRepositorio, VotacaoRepositorio>();

            var target = new Startup(configurationStub.Object);
            target.ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
            CaregaDadosParaTeste();        

        }

        #endregion

        #region Candidato


        [TestMethod]
        public void TesteRetornarCandidatosComSucesso()
        {
            candidatoRepositorio = RetornarCandidatoRepositorio();
            listaCandidatos = candidatoRepositorio.RetornarTodos();
            Assert.AreNotEqual(listaCandidatos.Count, 0);
        }
        

        #endregion

        #region Votacao       
       
        public void TesteVotacaoComSucesso()
        {        


        }

        [TestMethod]
        public void TesteRetornaTotalVotoDia()
        {
            votacaoRepositorio = RetornarVotacaoRepositorio();
            var x= (votacaoRepositorio.RetornarTodos());
        }

        #endregion

        #region Dispose

        [TestCleanup]
        public void RemoverTodosDados()
        {
            votacaoRepositorio = RetornarVotacaoRepositorio();

            var listavotacaodia = votacaoRepositorio.RetornarTodos();
            foreach (var item in listavotacaodia)
            {
                votacaoRepositorio.Remover(item);
            }


            candidatoRepositorio = RetornarCandidatoRepositorio();
            listaCandidatos = candidatoRepositorio.RetornarTodos();

            foreach (var item in listaCandidatos)
            {
                candidatoRepositorio.Remover(item);
            }
        }

        #endregion

    }
}
