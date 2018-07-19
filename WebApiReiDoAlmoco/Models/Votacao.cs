using System;
using System.Collections.Generic;

namespace WebApiReiDoAlmoco.Models
{
    public class Votacao : BaseModel
    {
        public virtual List<VotoCandidato> ListaCandidato { get; set; }
        public int TotalVoto { get; set; }
        public DateTime Data { get; set; }
    }
     
}


