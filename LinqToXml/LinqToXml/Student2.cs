using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToXml
{
    public class Student2
    {
        public string Name { get; set; }
        public int Class { get; set; }
        public int Maths { get; set; }
        public int Science { get; set; }
        public int History { get; set; }
        public static List<Student2> GetStudent2s()
        {
            List<Student2> student2s = new List<Student2>();

            student2s.Add(new Student2
            {
                Name = "Thomas",
                Class = 10,
                Maths = 85,
                Science = 89,
                History = 81
            });

            student2s.Add(new Student2
            {
                Name = "Luise",
                Class = 8,
                Maths = 82,
                Science = 80,
                History = 80
            });

            student2s.Add(new Student2
            {
                Name = "Rohan",
                Class = 6,
                Maths = 89,
                Science = 80,
                History = 86
            });

            student2s.Add(new Student2
            {
                Name = "Raj",
                Class = 10,
                Maths = 88,
                Science = 80,
                History = 86
            });

            return student2s;
        }
    }
}
