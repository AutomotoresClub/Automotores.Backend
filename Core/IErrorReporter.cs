using System;
using System.Threading.Tasks;

namespace Automotores.Backend.Core
{
    public interface IErrorReporter
    {
        Task CaptureAsync(Exception exception);

        Task CaptureAsync(string message);
    }
}