﻿using GraphQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.GraphQL.Types
{
    public class PublicacionInputType
    {
        public string Titulo { get; set; } = null!;

        public string Contenido { get; set; } = null!;

        public string ImagenUrl { get; set; } = null!;

        public EstadoPublicacion Estado { get; set; }

        public int Rating { get; set; }

        public int CategoriaId { get; set; }

        public int AutorId { get; set; }

    }
}
