using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMvc.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int IdUsaurio { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0: dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}