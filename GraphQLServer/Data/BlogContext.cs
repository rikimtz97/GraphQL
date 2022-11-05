using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.Data
{
    public class BlogContext : DbContext 
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; } = default!;

        public DbSet<Categoria> Categorias { get; set; } = default!;

        public DbSet<Publicacion> Publicaciones { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }

}

