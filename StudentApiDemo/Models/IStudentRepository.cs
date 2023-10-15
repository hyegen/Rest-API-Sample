using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApiDemo.Models
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Search(string name);
        Task<Student> GetStudent(int StudentID);
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(int StudentID);
    }
}
