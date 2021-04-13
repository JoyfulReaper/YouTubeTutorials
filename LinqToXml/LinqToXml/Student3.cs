//https://xmltocsharp.azurewebsites.net/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LinqToXml
{
    [XmlRoot(ElementName = "Subject")]
    public class Subject
    {
        [XmlAttribute(AttributeName = "Title")]
        public string Title { get; set; }
        [XmlText]
        public int Mark { get; set; }
    }

    [XmlRoot(ElementName = "Marks")]
    public class Marks
    {
        [XmlElement(ElementName = "Subject")]
        public List<Subject> Subject { get; set; }
    }

    [XmlRoot(ElementName = "Student")]
    public class Student
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Class")]
        public int Class { get; set; }
        [XmlElement(ElementName = "Marks")]
        public Marks Marks { get; set; }
    }

    [XmlRoot(ElementName = "Students")]
    public class Students
    {
        public Students()
        {
            Student = GetStudents();
        }

        [XmlElement(ElementName = "Student")]
        public List<Student> Student { get; set; }

        private static List<Student> GetStudents()
        {
            List<Student> Student = new List<Student>();

            Student.Add(new Student
            {
                Name = "Thomas",
                Class = 10,
                Marks = new Marks
                {
                    Subject = new List<Subject>
                    {
                    new Subject() {Title = "Maths", Mark = 96 },
                    new Subject() {Title = "Science", Mark = 83 },
                    new Subject() {Title = "History", Mark = 63 },
                    }
                }
            });

            Student.Add(new Student
            {
                Name = "Kyle",
                Class = 10,
                Marks = new Marks
                {
                    Subject = new List<Subject>
                    {
                    new Subject() {Title = "Maths", Mark = 64 },
                    new Subject() {Title = "Science", Mark = 83 },
                    new Subject() {Title = "History", Mark = 80 },
                    }
                }
            });

            Student.Add(new Student
            {
                Name = "Rohan",
                Class = 10,
                Marks = new Marks
                {
                    Subject = new List<Subject>
                    {
                    new Subject() {Title = "Maths", Mark = 92 },
                    new Subject() {Title = "Science", Mark = 80 },
                    new Subject() {Title = "History", Mark = 75 },
                    }
                }
            });

            Student.Add(new Student
            {
                Name = "Raj",
                Class = 10,
                Marks = new Marks
                {
                    Subject = new List<Subject>
                    {
                    new Subject() {Title = "Maths", Mark = 87 },
                    new Subject() {Title = "Science", Mark = 86 },
                    new Subject() {Title = "History", Mark = 75 },
                    }
                }
            });

            return Student;
        }
    }
}
