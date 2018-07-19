using System.Collections.Generic;
using WebApiReiDoAlmoco.Models;

namespace WebApiReiDoAlmoco.Interfaces
{
    public interface ICandidato: IBase
    {       
        Candidato Retornar(string email);        
       
    }
}
