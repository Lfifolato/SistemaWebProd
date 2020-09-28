using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaMvc.Models
{   
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }
       
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Valor:")]
        public float Valor { get; set; }
       
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Data de Validade:")]
        public string  Dvencimento { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio")]
        [Display(Name = "Fornecedor:")]
        [ForeignKey("Fornecedor")]
        public long IdFornecedor { get; set; }

        [Required(ErrorMessage = "Compo Obrigatorio")]
        [Display(Name = "Tipo:")]
        public string Tipo { get; set; }

        /*EF Relation*/

        public Fornecedor Fornecedor { get; set; }
    }
}