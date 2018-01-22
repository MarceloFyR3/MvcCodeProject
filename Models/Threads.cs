using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjetoMvc.Models
{
    public partial class Threads
    {
        public string Nome { get; set; }
        public int Numero { get; set; }
        public string Resultado { get; set; }
        public string ddlTipo { get; set; }
        public string ErroSelect { get; set; }

    }

}