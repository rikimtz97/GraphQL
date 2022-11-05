using GraphQLServer.Data;
using GraphQLServer.GraphQL.Types;
using GraphQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.GraphQL
{
    public class Mutation
    {

        public async Task<PublicacionPayload> CreatePublicacion(BlogContext context,
            PublicacionInputType inputPublicacion)
        {
            var publicacion = new Publicacion()
            {
                AutorId = inputPublicacion.AutorId,
                CategoriaId = inputPublicacion.CategoriaId,
                Contenido = inputPublicacion.Contenido,
                Estado = inputPublicacion.Estado,
                ImagenUrl = inputPublicacion.ImagenUrl,
                Rating = inputPublicacion.Rating,
                Titulo = inputPublicacion.Titulo,

            };
            await context.Publicaciones.AddAsync(publicacion);
            await context.SaveChangesAsync();

            return new PublicacionPayload
            {
                Id = publicacion.Id,
                AutorId = publicacion.AutorId,
                CategoriaId = publicacion.CategoriaId,
                Contenido = publicacion.Contenido,
                Estado = publicacion.Estado,
                ImagenUrl = publicacion.ImagenUrl,
                Rating = publicacion.Rating,
                Titulo = publicacion.Titulo,
            };
        }

    }
}
