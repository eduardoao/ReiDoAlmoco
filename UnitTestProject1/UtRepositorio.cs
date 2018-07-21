using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WebMvcDoAlmoco;
using WebMvcDoAlmoco.Interfaces;
using WebMvcDoAlmoco.Models;
using WebMvcDoAlmoco.Repositorio;
using WebMvcReiDoAlmoco.Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class UtRepositorio
    {

        #region Atributos
        private string connectionstring = "Data Source = DESKTOP-H0I2H73; Initial Catalog = ReiDoAlmoco; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        private Mock<IConfigurationSection> configurationSectionStub;
        Mock<IConfiguration> configurationStub;
        private IServiceCollection services;
        private ICandidatoRepositorio candidatoRepositorio;
        private IEleicaoRepositorio votacaoRepositorio;
        private ServiceProvider ServiceProvider;

        private Candidato candidato;
        private Candidato candidato1;
        private Candidato candidato2;

        private Voto voto1;
        private Voto voto2;

        private IList<BaseModel> listaCandidatos;
        #endregion
        
        #region Métodos Privados
        private ICandidatoRepositorio RetornarCandidatoRepositorio()
        {
            return ServiceProvider.GetService<ICandidatoRepositorio>();
        }

        private IEleicaoRepositorio RetornarVotacaoRepositorio()
        {
            return ServiceProvider.GetService<IEleicaoRepositorio>();
        }

        private void CaregaDadosParaTeste()
        {
            candidato = new Candidato { Email = "eoalcantara@gmail.com", Nome = "Eduardo Alcantara" };
            candidatoRepositorio = RetornarCandidatoRepositorio();
            candidatoRepositorio.Adicionar(candidato);

            candidato1 = new Candidato { Email = "eoalcantara@gmail.com", Nome = "Eduardo Alcantara" };
            candidato2 = new Candidato { Email = "regina@gmail.com", Nome = "Regina Alcantara" };
            voto1 = new Voto { Candidato = candidato1, Total = 1 };
            voto2 = new Voto { Candidato = candidato2, Total = 1 };

            var listacandidatos = new List<Voto>
            {
                voto1,
                voto2
            };

            var eleicao = new Eleicao { Data = DateTime.Now, Voto = listacandidatos, TotalVoto = listacandidatos.Count };

            votacaoRepositorio = RetornarVotacaoRepositorio();
            votacaoRepositorio.Adicionar(eleicao);

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
            services.AddTransient<IEleicaoRepositorio, EleicaoRepositorio>();
            services.AddTransient<IVotoRepositorio, VotoRepositorio>();

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
       
        [TestMethod]
        public void TesteVotacaoComSucesso()
        {
            var retornarEleicoes = votacaoRepositorio.RetornarTodos();


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
