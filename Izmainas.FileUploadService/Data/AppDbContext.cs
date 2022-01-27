using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Izmainas.FileUploadService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Izmainas.FileUploadService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<TeacherScheduleItem>().HasKey(x => x.Id);
        }

        public DbSet<TeacherScheduleItem> TeacherScehduleItems { get; set; }
        public DbSet<StudentScheduleItem> StudentScehduleItems { get; set; }
    }
}