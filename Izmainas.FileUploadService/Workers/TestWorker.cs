using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Domain.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Izmainas.FileUploadService.Workers
{
    public class TestWorker : BackgroundService
    {
        private readonly ILogger<TestWorker> _logger;
        private readonly HttpClient _httpClient;
        private readonly IExcelRepository _excelRepository;

        public TestWorker(
            HttpClient httpClient, 
            ILogger<TestWorker> logger, 
            IExcelRepository excelRepository)
        {
            _httpClient = httpClient;
            _logger = logger;
            _excelRepository = excelRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await _httpClient.GetAsync("https://www.iamtimcorey.com");
                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"The site is up: {result.StatusCode}");
                }
                else
                {
                    _logger.LogError($"The site is down: {result.StatusCode}");
                }
                await Task.Delay(5000, stoppingToken);
            }
        }

        // TODO: modify to work with both student and teacher items
        private async Task LoadFromExcelToDb(string path, int sheet)
        {
            var studentItems = await _excelRepository.GetAllSAsync(path, sheet);
            //C:\Users\user\Desktop\school_shit\informatika\zpd\saraksti\final\student_schedule.xlsx
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _httpClient.Dispose();
            return base.StopAsync(cancellationToken);
        }
    }
}