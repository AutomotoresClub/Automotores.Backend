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
    public class DepartamentoController : Controller
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;
        public DepartamentoController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("/api/departamentos")]
        public async Task<IEnumerable<KeyValuePairResource>> GetDepartamentos()
        {
            var departamentos = await context.Departamentos.ToListAsync();

            return mapper.Map<List<Departamento>, List<KeyValuePairResource>>(departamentos);
        }
    }
}