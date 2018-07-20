using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcDoAlmoco.Models.VotacaoViewModel
{
    public class EleicaoViewModel
    {
        public virtual IList<Voto> Voto { get; set; }
        public virtual IList<Candidato> CandidatoVotos { get; set; }
        public int VotoId { get; set; }
        public int TotalVoto { get; set; }
        public DateTime Data { get; set; }


    }
}
