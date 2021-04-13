// https://www.youtube.com/watch?v=H6AvBDcTn3g

using System.Xml.Linq;
using System.Linq;
using System;
using System.IO;
using System.Xml.Serialization;

namespace LinqToXml
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Test1();

            //BuildStudent2Xml();
            //CreateXml();
            //ReadStudent2Xml();
            //CreateXmlDocument();
            //CreateXmlDocumentInMemory();
        }

        public static void Test1()
        {
            var sts = new Students();
            XmlSerializer xs = new XmlSerializer(typeof(Students));

            using (Stream s = File.Create(@"C:\GitHub\YouTubeTutorials\LinqToXml\LinqToXml\data5.xml"))
                xs.Serialize(s, sts);
        }

        public static void CreateXml()
        {
            var data = new XElement("Persons",
                            new XElement("Person",
                                new XElement("Name", "Raj"),
                                new XElement("Age", 32)),
                                                        new XElement("Person",
                                new XElement("Name", "Tom"),
                                new XElement("Age", 30))
                            );

            File.WriteAllText(@"C:\GitHub\YouTubeTutorials\LinqToXml\LinqToXml\data4.xml", data.ToString());
        }

        public static void ReadStudent2Xml()
        {
            var filePath = @"C:\GitHub\YouTubeTutorials\LinqToXml\LinqToXml\data3.xml";
            var studentsData = XElement.Load(filePath);
            var data = studentsData.Descendants("Student").Where(st => (int)st.Element("Class") == 10);

            var data2 = studentsData.Descendants("Student").Where(st =>
           {
               var subjects = st.Element("Marks").Descendants("Subject");
               var mathSubject = subjects.FirstOrDefault(sub => (string)sub.Attribute("Title") == "Maths");
               return (int)mathSubject > 85;
           });

            // Class 10
            foreach(var student in data)
            {
                Console.WriteLine($" {student.Element("Name").Value }");

                var marks = student.Descendants("Subject");
                foreach(var item in marks)
                {
                    Console.WriteLine($"    {item.Attribute("Title").Value} : {item.Value}");
                }
            }

            // Math Marks > 85
            Console.WriteLine();
            foreach (var student in data2)
            {
                Console.WriteLine($" {student.Element("Name").Value }");

                var marks = student.Descendants("Subject");
                foreach (var item in marks)
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
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Creating an XML Tree using LINQ to XML"),
                new XElement("Students",
                from student in Student1.GetAllStudents()
                select new XElement("Student", new XAttribute("Id", student.Id),
                    new XElement("Name", student.Name),
                    new XElement("Gender", student.Gender),
                    new XElement("TotalMarks", student.TotalMarks))
                ));

            xmlDocument.Save(@"C:\GitHub\YouTubeTutorials\LinqToXml\LinqToXml\data2.xml");
        }

        public static void CreateXmlDocument()
        {
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