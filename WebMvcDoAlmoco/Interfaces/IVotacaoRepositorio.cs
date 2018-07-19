using System;
using WebMvcDoAlmoco.Models;


namespace WebMvcReiDoAlmoco.Interfaces
{
    public interface IVotacaoRepositorio: IBase
    {
        Votacao Retornar(DateTime data);
        
    }
}
