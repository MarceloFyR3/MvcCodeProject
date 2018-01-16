using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMvc.Models
{    
    public partial class Threads
    {      
        public string Nome { get; set; }       
    }

    public class listaEventos
    {
        public int Numero { get; set; }

        public string Descricao { get; set; }
    }
}