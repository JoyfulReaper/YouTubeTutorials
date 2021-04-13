using System.Xml.Linq;
using System.Linq;
using System;

namespace LinqToXml
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //BuildStudent2Xml();
            ReadStudent2Xml();
            //CreateXmlDocument();
            //CreateXmlDocumentInMemory();
        }

        public static void ReadStudent2Xml()
        {
            var filePath = @"C:\GitHub\YouTubeTutorials\LinqToXml\LinqToXml\data3.xml";
            var studentsData = XElement.Load(filePath);
            var data = studentsData.Descendants("Student").Where(st => (int)st.Element("Class") == 10);

            foreach(var student in data)
            {
                Console.WriteLine($" {student.Element("Name").Value }");

                var marks = student.Descendants("Subject");
                foreach(var item in marks)
                {
                    Console.WriteLine($"    {item.Attribute("Title").Value} : {item.Value}");
                }
            }
        }

        public static void BuildStudent2Xml()
        {
            var students =
                new XDocument(
                new XElement("Students",
                    from s in Student2.GetStudent2s()
                    select 
                    new XElement("Student",
                    new XElement("Name", s.Name),
                    new XElement("Class", s.Class),
                    new XElement("Marks",
                    new XElement("Subject", new XAttribute("Title", "Maths"), s.Maths),
                    new XElement("Subject", new XAttribute("Title", "Science"), s.Science),
                    new XElement("Subject", new XAttribute("Title", "History"), s.Maths))
                    )));
            students.Save(@"C:\GitHub\YouTubeTutorials\LinqToXml\LinqToXml\data3.xml");
            System.Console.WriteLine(students.ToString());
        }

        public static void CreateXmlDocumentInMemory()
        {
            //Obsolete
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Creating an XML Tree using LINQ to XML"),
                new XElement("Students",
                from student in Student.GetAllStudents()
                select new XElement("Student", new XAttribute("Id", student.Id),
                    new XElement("Name", student.Name),
                    new XElement("Gender", student.Gender),
                    new XElement("TotalMarks", student.TotalMarks))
                ));

            xmlDocument.Save(@"C:\GitHub\YouTubeTutorials\LinqToXml\LinqToXml\data2.xml");
        }

        public static void CreateXmlDocument()
        {
            //Obsolete
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),

                new XComment("Creating an XML Tree using LINQ to XML"),

                new XElement("Students",

               new XElement("Student", new XAttribute("Id", 101),
                    new XElement("Name", "Mark"),
                    new XElement("Gender", "Male"),
                    new XElement("TotalMarks", "800")),
                new XElement("Student", new XAttribute("Id", 102),
                    new XElement("Name", "Rosy"),
                    new XElement("Gender", "Female"),
                    new XElement("TotalMarks", "900")),
                new XElement("Student", new XAttribute("Id", 103),
                    new XElement("Name", "Pam"),
                    new XElement("Gender", "Female"),
                    new XElement("TotalMarks", "850")),
                new XElement("Student", new XAttribute("Id", 104),
                    new XElement("Name", "John"),
                    new XElement("Gender", "Male"),
                    new XElement("TotalMarks", "950"))));

            xmlDocument.Save(@"C:\GitHub\YouTubeTutorials\LinqToXml\LinqToXml\data.xml");
        }
    }
}