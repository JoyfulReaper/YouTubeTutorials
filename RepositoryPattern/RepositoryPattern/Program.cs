using System;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using( var unitOfWork = new UnitOfWork(new PlutoContext))
            {
                var course = unitOfWork.Courses.Get(1);

                var course = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

                var author = unitOfWork.Authors.GetAuthourWithCourses(1);
                unitOfWork.Courses.RemoveRange(author.Courses);
                unitOfWork.Authors.Remove(author);
                unitOfWork.Complete();
            }
        }
    }
}
