using System;
using System.Collections.Generic;
using WebMvcDoAlmoco.Models;


namespace WebMvcReiDoAlmoco.Interfaces
{
    public interface IEleicaoRepositorio: IBase
    {
        Eleicao Retornar(DateTime data);

        void Atualizar(Eleicao eleicao);

        new IList<Eleicao> RetornarTodos();
    }
}
