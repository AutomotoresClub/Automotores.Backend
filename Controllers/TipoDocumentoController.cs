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
    public class TipoDocumentoController
    {
        private readonly AutomotoresDbContext context;
        private readonly IMapper mapper;
        public TipoDocumentoController(AutomotoresDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet("/api/tipo-documento")]
        public async Task<IEnumerable<KeyValuePairResource>> GetTipoDocumento()
        {
            var tipoDocumento = await context.TipoDocumento.ToListAsync();

            return mapper.Map<List<TipoDocumento>, List<KeyValuePairResource>>(tipoDocumento);
        }
    }
}