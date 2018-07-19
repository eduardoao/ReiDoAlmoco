using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using WebMvcDoAlmoco.Models;
using WebMvcReiDoAlmoco;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Repositorio
{
    public class VotacaoRepositorio : BaseRepository<Votacao>, IVotacaoRepositorio
    {
             

        public VotacaoRepositorio(ApplicationContext contexto) : base(contexto)
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

        public Votacao Retornar(DateTime data)
        {
            return contexto.Votacao.Find(data);
        }

        public IList<BaseModel> RetornarTodos()
        {
            IQueryable<BaseModel> retorno = contexto.Set<Votacao>();
            return retorno.ToList();
        }
    }
}
