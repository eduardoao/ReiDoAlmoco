using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcDoAlmoco.Models
{
    public class VotoCandidato : BaseModel
    {
        public Candidato Candidato { get; set; }
        public int Voto { get; set; }
    }
}
