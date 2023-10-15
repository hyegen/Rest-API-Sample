using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApiDemo.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var result = await appDbContext.Students.AddAsync(student);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStudent(int studentID)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync(e => e.ID == studentID);
            if (result!=null)
            {
                appDbContext.Students.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudent(int StudentID)
        {
            return await appDbContext.Students.FirstOrDefaultAsync(e=>e.ID==StudentID);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await appDbContext.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> Search(string name)
        {
            IQueryable<Student> query = appDbContext.Students;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.NAME.Contains(name) || e.SURNAME.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await appDbContext.Students.FirstOrDefaultAsync(e => e.ID == student.ID);
            if (result!=null)
            {
                result.NAME = student.NAME;
                result.SURNAME = student.SURNAME;
                result.MARKS = student.MARKS;
                //resultID = student.DEPARTMENTID;
                //if (student.DEPARTMENTID !=0)
                //{
                //    result.DEPARTMENTID = student.DEPARTMENTID;
                //}
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
