using EventsApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApi.Data
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions options)
            : base(options)
        { }

        //create table
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventItem> EventItems { get; set; }

        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(e =>
            {
                e.ToTable("EventTypes");
                e.Property(t => t.Id)
                    .IsRequired()
                    .UseHiLo("event_type_hilo");
                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventItem>(e =>
            {
                e.ToTable("events");
                e.Property(c => c.Id)
                    .IsRequired()
                    .UseHiLo("event_item_hilo");
                e.Property(c => c.Name)
                    .IsRequired();
                e.Property(c => c.Price)
                    .IsRequired();
                e.Property(c => c.Location)
                    .IsRequired();
                e.HasOne(c => c.EventType)
                    .WithMany()
                    .HasForeignKey(c => c.EventTypeId);
             });
        }
    }
}
