using System.Collections.Generic;
using System.Collections.ObjectModel;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Controllers.Resources
{
    public class AdministradorResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}