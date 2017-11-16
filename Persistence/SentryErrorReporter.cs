using System;
using System.Threading.Tasks;
using Automotores.Backend.Core;
using Microsoft.Extensions.Options;
using SharpRaven;
using SharpRaven.Data;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Persistence
{
    public class SentryErrorReporter : IErrorReporter
    {
        private readonly IRavenClient _client;

        public SentryErrorReporter(IOptions<SentryOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrEmpty(options.Value.Dsn))
                throw new ArgumentNullException("Can not construct a SentryErrorReporter without a valid DSN!");

            _client = new RavenClient(options.Value.Dsn);
        }


        public async Task CaptureAsync(Exception exception)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));

            await _client.CaptureAsync(new SentryEvent(exception));
        }

        public async Task CaptureAsync(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            await _client.CaptureAsync(new SentryEvent(message));
        }
    }
}