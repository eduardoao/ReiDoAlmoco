using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvcDoAlmoco.Models;
using WebMvcReiDoAlmoco.Interfaces;

namespace WebMvcDoAlmoco.Interfaces
{
    public interface IVotoRepositorio: IBase
    {
        Voto RetornarId(int id);
        Voto RetornarCandidato(int idCandidato);
        IList<Voto> RetornarIdEleicao(int idEleicao);

        void Atualizar(Voto voto);
    }
}
