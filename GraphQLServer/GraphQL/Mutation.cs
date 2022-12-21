using AutoMapper;
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
            [Service] IMapper mapper,
            PublicacionInputType inputPublicacion)
        {
            var publicacion = mapper.Map<Publicacion>(inputPublicacion);

            await context.Publicaciones.AddAsync(publicacion);
            await context.SaveChangesAsync();

            return mapper.Map<PublicacionPayload>(publicacion);

        }
        public async Task<PublicacionPayload>UpdatePublicacion(BlogContext context,
            [Service]IMapper mapper,
            int id, PublicacionInputType inputPublicacion)
        {
            var publicacion = mapper.Map<Publicacion>(inputPublicacion);
            publicacion.Id = id;
            context.Publicaciones.Update(publicacion);
            await context.SaveChangesAsync();
            return mapper.Map<PublicacionPayload>(publicacion);

        }
        public async Task<bool> DeletePublicacion(BlogContext context, int id)
        {
            try
            {
                var publicacionBd = await context.Publicaciones.FindAsync(id);
                if(publicacionBd is null) return false;

                context.Publicaciones.Remove(publicacionBd);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
