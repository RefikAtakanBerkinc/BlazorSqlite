using BlazorSqlite.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorSqlite.Services
{
    public class StudentService : IStudentService
    {


        private readonly StudentDataContext _studentData;

        public StudentService(StudentDataContext studentData)
        {
            _studentData = studentData;
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentData.Students.FirstOrDefaultAsync(s => s.Id == id);
        }


        public async Task AddStudentAsync(Student student)
        {
            _studentData.Students.Add(student);
            await _studentData.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int Id)
        {
            var student = await _studentData.Students.FindAsync(Id);
            if(student != null)
            {
                _studentData.Students.Remove(student);
                await _studentData.SaveChangesAsync();
            }
        }

        public async Task EditStudentAsync(Student student)
        {
            var std = await _studentData.Students.FirstOrDefaultAsync(s => s.Id==student.Id);
            if(std != null)
            {
                std.FirstName = student.FirstName;
                std.LastName = student.LastName;
                await _studentData.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _studentData.Students.ToListAsync();
        }
    }
}
