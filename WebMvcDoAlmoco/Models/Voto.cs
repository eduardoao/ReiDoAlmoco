namespace WebMvcDoAlmoco.Models
{
    public class Voto : BaseModel
    {       
        public virtual Candidato Candidato { get; set; }
        public int CandidatoId { get; set; }
        public int Total { get;  set; }


        public Eleicao Eleicao { get; set; }
        public int EleicaoId { get; set; }
    }
}
