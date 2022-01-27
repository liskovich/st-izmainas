using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Workers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Izmainas.FileUploadService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly JokeService _jokeService;

        public Worker(ILogger<Worker> logger, JokeService jokeService)
        {
            _logger = logger;
            _jokeService = jokeService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string joke = await _jokeService.GetJokeAsync();
                _logger.LogWarning(joke);
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

                
            }
        }
    }
}
