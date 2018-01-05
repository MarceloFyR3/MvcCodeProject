using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoMvc.Models;

    public class ProjetoMvcContext : DbContext
    {
        public ProjetoMvcContext (DbContextOptions<ProjetoMvcContext> options)
            : base(options)
        {
        }
        public DbSet<ProjetoMvc.Models.Usuario> Usuario { get; set; }

    }   
