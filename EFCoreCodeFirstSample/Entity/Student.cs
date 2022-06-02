using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Entity
{
    internal class Student
    {

        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[]? Photo { get; set; }
        public decimal? Height { get; set; }
        public float? Weight { get; set; }
        public int GradeId { get; set; }
        public Grade? Grade { get; set; }
        public StudentAddress? Address { get; set; }
    }


}
