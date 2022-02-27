using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Domain.Constants;
using Izmainas.FileUploadService.Domain.Dtos;
using Izmainas.FileUploadService.Domain.Exceptions;
using Izmainas.FileUploadService.Domain.Services;

namespace Izmainas.FileUploadService.Services
{
    public class NetworkService : INetworkService
    {
        private readonly HttpClient _httpClient;

        public NetworkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendAllSAsync(List<StudentScheduleDto> items)
        {
            try
            {
                var request = new StudentScheduleRequest(items);
                await Send(request, ServerOptions.StudentsEndpoint);
            }
            catch (NetworkException ex)
            {
                // TODO: replace with proper handling
                Console.WriteLine(ex.Message);
            }
        }

        public async Task SendAllTAsync(List<TeacherScheduleDto> items)
        {
            try
            {
                var request = new TeacherScheduleRequest(items);
                await Send(request, ServerOptions.TeachersEndpoint);
            }
            catch (NetworkException ex)
            {
                // TODO: replace with proper handling
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Send<U>(U item, string route)
        {
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(route, content);
            if (!result.IsSuccessStatusCode)
            {
                throw new NetworkException();
            }
        }
    }
}