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
    public class CiudadController : Controller
    {
        private readonly IMapper mapper;
        private readonly AutomotoresDbContext context;
        public CiudadController(AutomotoresDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/ciudades/{departamentoId}")]
        public async Task<IEnumerable<KeyValuePairResource>> GetCiudad(int departamentoId)
        {

            var ciudades = await context.Ciudades.Where(c => c.DepartamentoId == departamentoId).ToListAsync();

            return mapper.Map<List<Ciudad>, List<KeyValuePairResource>>(ciudades);
        }
    }
}