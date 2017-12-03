using System;

namespace Automotores.Backend.Controllers.Resources
{
    public class VehiculoResource
    {
        public int Id { get; set; }

        public string Placa { get; set; }

        public string Modelo { get; set; }

        public string Imagen { get; set; }

        public DateTime VigenciaTecnomecanica { get; set; }

        public DateTime? VigenciaTodoriesgo { get; set; }

        public DateTime VigenciaSoat { get; set; }

        public KeyValuePairResource Ciudad { get; set; }

        public KeyValuePairResource Departamento { get; set; }

        public KeyValuePairResource Linea { get; set; }

        public KeyValuePairResource Marca { get; set; }

        public KeyValuePairResource ServicioVehiculo { get; set; }

        public KeyValuePairResource ColorVehiculo { get; set; }
    }
}