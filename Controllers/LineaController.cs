using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Controllers
{
    [Route("/api/linea")]
    public class LineaController : Controller
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;

        public LineaController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [Route("~/api/marca/{id}/lineas")]
        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetLineas(int id)
        {
            var lineas = await context.Lineas.Where(l => l.Id == id).ToListAsync();

            return mapper.Map<List<Linea>, List<KeyValuePairResource>>(lineas);
        }
    }
}