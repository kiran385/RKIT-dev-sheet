using System;

namespace StudentManagementSystem
{
    internal enum Year
    {
        FirstYear = 1,
        SecondYear,
        ThirdYear,
        FourthYear
    }

    internal interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    internal class Person : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Student : Person
    {
        public int StudentId { get; set; }
        public Year AcademicYear { get; set; }
    }
}
