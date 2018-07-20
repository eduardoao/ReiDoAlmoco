using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcDoAlmoco.Models.VotacaoViewModel
{
    public class CandidatoViewModel: BaseModel
    {
        public Candidato Candidato { get; set; }
        public string Imagem  { get; set; }
      
    }
}
