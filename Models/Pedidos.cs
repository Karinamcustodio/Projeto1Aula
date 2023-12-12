using System.ComponentModel.DataAnnotations;

namespace RepresentanteMVC.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        public DateTime Data { get; set;}
        public double Valor { get; set;}

        [Display(Name = "Comissão")] 
        public double PercentualComissao { get; set; }
        public int RepresentanteId { get; set; }
        public int EmpresaId { get; set; }
        public int LojaId { get; set; }

        public virtual Representante Representante { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Loja Loja { get; set; }
    }
}
