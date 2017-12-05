using System.IO;
using System.Linq;

namespace Automotores.Backend.Core.Models
{
    public class FotosConfiguracion
    {
        public int MaxBytes { get; set; }

        public string[] AcceptedFileTypes { get; set; }

        public bool IsSuported(string fileName)
        {
            return AcceptedFileTypes.Any(s => s == Path.GetExtension(fileName).ToLower());
        }
    }
}