using System.ComponentModel.DataAnnotations;

namespace RepresentanteMVC.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Display(Name = "Empresa")] 
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string InscEstadual { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        [Display(Name = "Ativo")] 
        public bool Status { get; set; }
        
    }
}
