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
    public class MarcaController : Controller
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;

        public MarcaController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [Route("/api/clasevehiculo/{id}/marcas")]
        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetMarcas(int id)
        {
            var marcas = await context.Marcas.Where(marca => marca.Id == id).ToListAsync();

            return mapper.Map<List<Marca>, List<KeyValuePairResource>>(marcas);
        }
    }
}