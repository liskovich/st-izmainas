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
    /// <summary>
    /// Class used for sending data to API
    /// </summary>
    public class NetworkService : INetworkService
    {
        private readonly HttpClient _httpClient;

        public NetworkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Method used for sending student schedule data to API
        /// </summary>
        /// <param name="items">Student data to send</param>        
        public async Task SendAllSAsync(List<StudentScheduleDto> items)
        {
            try
            {
                var request = new StudentScheduleRequest(items);
                await Send(request, ServerOptions.BaseAddress + ServerOptions.StudentsEndpoint);
            }
            catch (NetworkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Method used for sending teacher schedule data to API
        /// </summary>
        /// <param name="items">Teacher data to send</param>   
        public async Task SendAllTAsync(List<TeacherScheduleDto> items)
        {
            try
            {
                var request = new TeacherScheduleRequest(items);
                await Send(request, ServerOptions.BaseAddress + ServerOptions.TeachersEndpoint);
            }
            catch (NetworkException ex)
            {
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