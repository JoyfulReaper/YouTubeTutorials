using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToXml
{
    public class Student1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int TotalMarks { get; set; }

        public static Student1[] GetAllStudents()
        {
            Student1[] students = new Student1[4];

            students[0] = new Student1 { Id = 101, Name = "Mark", Gender = "Male", TotalMarks = 800 };
            students[1] = new Student1 { Id = 102, Name = "Rosy", Gender = "Female", TotalMarks = 900 };
            students[2] = new Student1 { Id = 103, Name = "Pam", Gender = "Female", TotalMarks = 850 };
            students[3] = new Student1 { Id = 104, Name = "John", Gender = "Male", TotalMarks = 950 };

            return students;
        }
    }
}
