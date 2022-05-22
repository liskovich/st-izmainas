using Izmainas.API.Domain.Entities;
// using Izmainas.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Izmainas.API.Datasource
{
    /// <summary>
    /// Application persistence level context
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Data set for storing notes
        /// </summary>
        public DbSet<Note> Notes { get; set; }

        /// <summary>
        /// Data set for storing student schedules
        /// </summary>
        public DbSet<StudentScheduleItem> StudentItems { get; set; }

        /// <summary>
        /// Data set for storing teacher schedules
        /// </summary>
        public DbSet<TeacherScheduleItem> TeacherItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentScheduleItem>()
            .HasKey(s => s.Id);

            modelBuilder.Entity<TeacherScheduleItem>()
            .HasKey(t => t.Id);            
        }
    }
}