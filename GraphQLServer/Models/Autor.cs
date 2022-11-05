using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.Models
{
    public class Autor
    {
            public int Id { get; set; }

            public string Nombre { get; set; } = null!;

            public string Apellidos { get; set; } = null!;

            public string CorreoElectronico { get; set; } = null!;

            public double Salario { get; set; }

            public ICollection<Publicacion> Publicaciones { get; set; } = null!;

    }

}
