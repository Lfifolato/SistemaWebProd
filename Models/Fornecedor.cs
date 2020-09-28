using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaMvc.Models
{   
    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "CNPJ:")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Site:")]
        public string Site { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail Invalido")]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Campo Obrigatorio")]      
        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }


        /*EF Relação*/

        public IEnumerable<Produto> Produtos { get; set; }
    }
}