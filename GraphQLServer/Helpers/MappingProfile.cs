using AutoMapper;
using GraphQLServer.GraphQL.Types;
using GraphQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Publicacion, PublicacionInputType>()
                .ReverseMap()
                .ForMember(u => u.Autor, pubInput => pubInput.Ignore())
                .ForMember(u => u.Categoria, pubInput => pubInput.Ignore());


            CreateMap<Publicacion, PublicacionPayload>()
               .ReverseMap()
               .ForMember(u => u.Autor, pubInput => pubInput.Ignore())
               .ForMember(u => u.Categoria, pubInput => pubInput.Ignore());
        }
    }
}
