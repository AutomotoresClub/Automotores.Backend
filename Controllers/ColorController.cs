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
    [Route("/api/colores")]
    public class ColorController : Controller
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;
        public ColorController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetColores()
        {
            var colores = await context.ColorVehiculo.ToListAsync();

            return mapper.Map<List<ColorVehiculo>, List<KeyValuePairResource>>(colores);
        }
    }
}