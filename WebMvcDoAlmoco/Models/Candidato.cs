using System.ComponentModel.DataAnnotations;

namespace WebMvcDoAlmoco.Models
{
    public class Candidato: BaseModel
    {
        [Required]
        [Display(Name = "Nome do Candidato")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }     

    }
}
