using System;
using System.Collections.Generic;

namespace WebMvcDoAlmoco.Models
{
    public class Eleicao : BaseModel
    {
        public virtual IList<Voto> Voto { get; set; }               
        public int VotoId { get; set; }       
        public int TotalVoto { get; set; }
        public DateTime Data { get; set; }
    }
     
}


