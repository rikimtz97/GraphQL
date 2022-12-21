using GraphQLServer.Data;
using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.GraphQL
{
    public class Query
    {
        [UseOffsetPaging(IncludeTotalCount =true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Publicacion> GetPublicaciones(BlogContext context)
            => context.Publicaciones;

        [UseFirstOrDefault]
        [UseProjection]
        public IQueryable<Publicacion?>GetPublicacion(BlogContext context, int id)
            => context.Publicaciones.Where(u => u.Id == id);

    }
}
