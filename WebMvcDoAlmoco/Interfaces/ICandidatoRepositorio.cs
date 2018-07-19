using System.Collections.Generic;
using WebMvcDoAlmoco.Models;


namespace WebMvcReiDoAlmoco.Interfaces
{
    public interface ICandidatoRepositorio: IBase
    {       
        Candidato Retornar(string email);       
       
    }
}
