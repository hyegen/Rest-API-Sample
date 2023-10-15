using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Search(string name)
        {
            try
            {
                var result = await studentRepository.Search(name);
                if (result.Any())
                {
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        
        public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return await studentRepository.GetStudents();
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpGet("{id:int}")]
        public async Task<Student> GetStudent(int id)
        {
            try
            {
                var result = await studentRepository.GetStudent(id);               
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpPost]
        public async Task<Student> CreateStudent(Student student)
        {
            try
            {
                var stu = await studentRepository.AddStudent(student);
                return stu;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<Student> UpdateStudent(int id, Student student)
        {
            try
            {
                var studentToUpdate = await studentRepository.GetStudent(id);
                if (studentToUpdate == null)
                {
                    return null;
                }
                return await studentRepository.UpdateStudent(student);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<Student> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await studentRepository.GetStudent(id);
                if (studentToDelete==null)
                {
                    return null;
                }
                await studentRepository.DeleteStudent(id);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
