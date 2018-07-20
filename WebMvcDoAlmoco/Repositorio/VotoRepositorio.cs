using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using WebMvcDoAlmoco.Interfaces;
using WebMvcDoAlmoco.Models;
using WebMvcReiDoAlmoco;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Repositorio
{
    public class VotoRepositorio : BaseRepository<Eleicao>, IVotoRepositorio
    {
        public VotoRepositorio(ApplicationContext contexto) : base(contexto)
        {
            
        }

        public void Adicionar(BaseModel baseModel)
        {        
             contexto.Add(baseModel);
             contexto.SaveChanges();
           
        }

        public void Remover(BaseModel baseModel)
        {
            contexto.Remove(baseModel);
            contexto.SaveChanges();
        }
      

        public Voto RetornarId(int id)
        {
            try
            {
                return contexto.Voto.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao acessar a base de dados. Descrição: {0}", ex.Message), ex);
            }

        }

        public Voto RetornarCandidato(int idcandidato)
        {
            try
            {
                return contexto.Voto.SingleOrDefault(v => v.CandidatoId == idcandidato);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao acessar a base de dados. Descrição: {0}", ex.Message), ex);
            }

        }        

        public IList<BaseModel> RetornarTodos()
        {
            IQueryable<BaseModel> retorno = contexto.Set<Voto>();
           return retorno.ToList();
        }

        public void Atualizar (Voto voto)
        {
            contexto.Voto.Update(voto);
            contexto.SaveChanges();
        }

        public IList<Voto>RetornarIdEleicao(int idEleicao)
        {
            try
            {
                var retorno =  contexto.Voto.Where(v => v.Eleicao.Id == idEleicao);
                return retorno.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao acessar a base de dados. Descrição: {0}", ex.Message), ex);
            }
        }

      
    }
}
