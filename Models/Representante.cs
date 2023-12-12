using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RepresentanteMVC.Models
{
    public class Representante
    {
        public int Id { get; set; }

        [Display(Name = "Representante")]
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Core { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }

        [Display(Name = "Ativo")] 
        public bool Status { get; set; }

        public string erro { get; set; }
    }
}
