// See https://aka.ms/new-console-template for more information
Console.WriteLine("Entity Framework Sample");



EFCoreCodeFirstSample.StudentCrud student = new EFCoreCodeFirstSample.StudentCrud();

student.SaveStudentData();

Console.WriteLine("Press any key to diplay student details");
Console.ReadKey();

student.DisplayStudentData();

Console.WriteLine("Press any key to diplay student Name = Bill");
Console.ReadKey();


student.GetStudentByName();

Console.WriteLine("Press any key to diplay student Name starts with Bill using RAW Sql Command");
Console.ReadKey();

student.GetStudentByNameUsingSqlQuery();

Console.WriteLine("Press any key to update Student Name");

Console.ReadKey();

student.UpdateStudentData();

Console.WriteLine("Display updated student data.");

student.DisplayStudentData();

Console.ReadKey();

Console.WriteLine("Delete student data.");

student.DeleteStudentData();

Console.ReadKey();

Console.WriteLine("Display student data after delete.");

Console.ReadKey();

student.DisplayStudentData();
