using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebMvcDoAlmoco.Models;
using WebMvcReiDoAlmoco;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Repositorio
{
    public class EleicaoRepositorio : BaseRepository<Eleicao>, IEleicaoRepositorio
    {
        public EleicaoRepositorio(ApplicationContext contexto) : base(contexto)
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

        public Eleicao Retornar(DateTime data)
        {

            //using (contexto)
            //{
                var eleicoes = contexto.Eleicao
                    .Include(v => v.Voto)
                    .ToList();

                return eleicoes.SingleOrDefault(c => c.Data == data);
            //}           
        }

        public Eleicao RetornarId(int id)
        {
            try
            {
                return contexto.Eleicao.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao acessar a base de dados. Descrição: {0}", ex.Message), ex);
            }

        }

    
        public void Atualizar(Eleicao eleicao)
        {
            contexto.Eleicao.Update(eleicao);
            contexto.SaveChanges();
        }

        public IList<Eleicao> RetornarTodos()
        {
            //using (contexto)
            //{
                var eleicoes = contexto.Eleicao
                    .Include(v => v.Voto)
                    .ToList();

                return eleicoes;
          //  }
        }

        IList<BaseModel> IBase.RetornarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
