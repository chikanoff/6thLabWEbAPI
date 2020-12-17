using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApp.Models;

#nullable disable

namespace WebApp.Data
{
    public partial class courseworkDbContext : DbContext
    {
        public courseworkDbContext()
        {
        }

        public courseworkDbContext(DbContextOptions<courseworkDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<TypesOfinsurance> TypesOfinsurances { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3DPM8BP\\SQLEXPRESS;Database=courseworkDb;Trusted_Connection=True;");
            }
        }
    }
}
