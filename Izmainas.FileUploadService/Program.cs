using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Data;
using Izmainas.FileUploadService.Domain.Constants;
using Izmainas.FileUploadService.Domain.Entities;
using Izmainas.FileUploadService.Domain.Services;
using Izmainas.FileUploadService.Services;
using Izmainas.FileUploadService.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Izmainas.FileUploadService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO: refactor app build process
            var app = CreateHostBuilder(args).Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(LogMessages.BuildLogFileLocation())
                .CreateLogger();

            // TODO: test code - remove later
            
            IExcelRepository excelRepository = new ExcelRepository();
            var studentItems = Task.Run(() => excelRepository.GetAllSAsync(
                @"C:\Users\user\Desktop\school_shit\informatika\zpd\saraksti\final\student_schedule.xlsx", 0)).Result;

            var dbItems = new List<StudentScheduleItem>();
            foreach (var item in studentItems)
            {
                var dbItem = new StudentScheduleItem()
                {                    
                    Lesson = item.Lesson,
                    Day = item.Day,
                    Subject = item.Subject,
                    Class = item.Class
                };
                dbItems.Add(dbItem);
            }
                        
                var scope = app.Services.CreateScope();
            
                var services = scope.ServiceProvider;
                ISqliteRepository sqliteRepository = new SqliteRepository(services.GetService<AppDbContext>());
                Task.Run(() => sqliteRepository.EnsureDatabaseCreated());
                Task.Run(() => sqliteRepository.InsertStudentSchedulesAsync(dbItems));
                //var test = Task.Run(() => sqliteRepository.SaveChangesAsync()).Result;

                // if (test)
                // {
                //     Console.WriteLine(true);
                // }

            // TODO: test code - remove later

            try
            {
                Log.Information(LogMessages.InfoMessages.StartingService);
                
                // TODO: refactor app build process
                app.Run();
                return;
            }
            catch (Exception ex)
            {             
                Log.Fatal(ex, LogMessages.ErrorMessages.FailedToStartService);
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService(options => 
                {
                    options.ServiceName = ServiceInfo.ServiceName;
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // TODO: setup the hosted service
                    //services.AddHostedService<TestWorker>();

                    // TODO: register http client factory
                    //services.AddHttpClient<TestWorker>();
                    
                    // TODO: register automapper                    

                    services.AddDbContext<AppDbContext>(
                        options => options.UseSqlite(SqliteConstants.BuildConnectionString()));
                    
                    // TODO: review service lifetime
                    services.AddScoped<ISqliteRepository, SqliteRepository>();
                    services.AddScoped<IExcelRepository, ExcelRepository>();
                    services.AddScoped<INetworkService, NetworkService>();
                })
                .UseSerilog();
    }
}
