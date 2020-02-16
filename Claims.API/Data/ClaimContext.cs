using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Claims.API.Models;
using Claims.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Claims.API.Data
{

    public class ClaimContext : DbContext
    {
        public ClaimContext(DbContextOptions<ClaimContext> options) : base(options)
        {
        }
            public DbSet<Claim> Claim { get; set; }
            public DbSet<Client> Client { get; set; }
            public DbSet<Product> Product { get; set; }
            public DbSet<InterruptionResaon> InterruptionResaon { get; set; }
            public DbSet<InterruptionConsequence> InterruptionConsequence { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InterruptionResaon>().HasData(new InterruptionResaon
            {
                Id = 1,
                ReasonId = "WEATHER",
                Reason = "Weather",
                Active = true
            });

            modelBuilder.Entity<InterruptionConsequence>().HasData(new InterruptionConsequence
            {
                Id = 1,
                ConsequenceId = "C",
                Consequence = "Cancellation",
                Active = true
            });

            modelBuilder.Entity<Claim>().HasData(new Claim
            {
                Id = 1,
               // ClaimCaseNumber = ,
                FirstName = "Pero",
                LastName = "Peric",
                Email = "pperic@mail.com",
                PolicyNumber = "1111111",
                OriginalFlightNumber = "OA123",
                OriginalFlightDate = DateTime.Now.AddDays(-3),
                InterruptionReason = "WEATHER",
                InterruptionConsequence = "C",
                NewFlightNumber = "OB123",
                NewFlightDate = DateTime.Now.AddDays(-2),
                Created = DateTime.Now.AddDays(-2)
            });
        }
    }

}