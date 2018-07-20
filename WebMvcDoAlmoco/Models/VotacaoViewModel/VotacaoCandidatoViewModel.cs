using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcDoAlmoco.Models.VotacaoViewModel
{
    public class VotacaoCandidatoViewModel
    {
        public int Id { get; set; }
        public string Resposta { get; set; }
        public IList<CandidatoViewModel> Candidatos { get; set; }

    }
}
