using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using WebMvcDoAlmoco.Models;
using WebMvcReiDoAlmoco;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Repositorio
{
    public class CandidatoRepositorio : BaseRepository<Candidato>, ICandidatoRepositorio
    {       

        public CandidatoRepositorio(ApplicationContext contexto) : base(contexto)
        {
            
        }


        public void Adicionar(BaseModel baseModel)
        {
            try
            {
                contexto.Add(baseModel);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao acessar a base de dados. Descrição: {0}", ex.Message), ex);
            }            
           
        }

        public void Remover(BaseModel baseModel)
        {
            try
            {
                contexto.Remove(baseModel);
                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao acessar a base de dados. Descrição: {0}", ex.Message), ex);
            }
            
        }

        public Candidato Retornar(string email)
        {
            try
            {
                return contexto.Candidato.Find(email);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao acessar a base de dados. Descrição: {0}", ex.Message), ex);
            }
           
        }

        public IList<BaseModel> RetornarTodos()
        {
            try
            {
                IQueryable<BaseModel> retorno = contexto.Set<Candidato>();
                return retorno.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao acessar a base de dados. Descrição: {0}", ex.Message), ex);
            }
            
        }
    }
}
