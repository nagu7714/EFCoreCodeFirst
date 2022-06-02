using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstSample.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EFCoreCodeFirstSample.Context
{
    internal class StudentContext :DbContext
    {
          

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SchoolDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasOne<StudentAddress>(S => S.Address)
                .WithOne(g => g.Student)
                .HasForeignKey<StudentAddress>(ad=>ad.AddressOfStudentId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Grade>? Grades { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<StudentAddress>? StudentAddresses { get; set; }

    }
}
