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
    [Route("/api/mercado")]
    public class MercadoController : Controller
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;
        public MercadoController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetMercado()
        {
            var mercado = await context.Mercado.ToListAsync();

            return mapper.Map<List<Mercado>, List<KeyValuePairResource>>(mercado);
        }
    }
}