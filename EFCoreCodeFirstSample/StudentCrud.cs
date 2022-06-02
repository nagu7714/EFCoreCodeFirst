using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreCodeFirstSample.Context;
using EFCoreCodeFirstSample.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirstSample
{
    public class StudentCrud
    {

        public void SaveStudentData()
        {
            using (var context= new StudentContext())
            {

                var students = new List<Student>() {
                new Student(){  StudentName="Bill"},
                new Student(){  StudentName="Steve"},
                new Student(){  StudentName="Ram"},
                new Student(){  StudentName="Abdul"},
                new Student(){  StudentName="Bill Turner"},
            };

                Console.WriteLine("Saving Student Data");

                context.Students?.AddRange(students);
                context.SaveChanges();

                Console.WriteLine("Student data Saved to DB.");
            }
        }

        public void DisplayStudentData()
        {
            var context = new StudentContext();

            var students =context.Students;
            if (students != null)
            {
                foreach (Student std in students)
                {
                    Console.WriteLine("ID : {0} || Name : {1}", std.StudentID, std.StudentName);
                }
            }
        }
        public void GetStudentByName()
        {

            var context = new StudentContext();

            var student = context.Students?
                .Where(s => s.StudentName == "Bill").ToList();
            if (student != null)
            {
                foreach (Student std in student)
                {
                    Console.WriteLine("ID : {0} || Name : {1}", std.StudentID, std.StudentName);
                }
            }


        }

        public void GetStudentByNameUsingSqlQuery()
        {

            var context = new StudentContext();

            var student = context.Students?.FromSqlRaw("select * from  Students where StudentName like 'Bill%'").OrderBy(s => s.StudentName);
            if (student != null)
            {
                foreach (Student std in student)
                {
                    Console.WriteLine("ID : {0} || Name : {1}", std.StudentID, std.StudentName);
                }
            }


        }

        public void UpdateStudentData()
        {
            using (var context = new StudentContext())
            {
                var students = context.Students?.First<Student>();
                if (students != null)
                {
                    students.StudentName = "Steve";
                    context.SaveChanges();
                }
            }
        }

        public void DeleteStudentData()
        {
            using (var context = new StudentContext())
            {
                var students = context.Students?.First<Student>();
                {
                    if (students != null)
                    {
                        context.Students?.Remove(students);
                        context.SaveChanges();

                    }
                }
            }
        }
    }
}
