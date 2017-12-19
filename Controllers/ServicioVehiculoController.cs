using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Controllers
{
    [Route("/api/servicioVehiculo")]
    public class ServicioVehiculoController : Controller
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;
        public ServicioVehiculoController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetServicioVehiculo()
        {
            var servicios = await context.ServicioVehiculo.ToListAsync();

            return mapper.Map<List<ServicioVehiculo>, List<KeyValuePairResource>>(servicios);
        }
    }
}