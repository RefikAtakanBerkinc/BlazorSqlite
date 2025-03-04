using BlazorSqlite.Data;

namespace BlazorSqlite.Services
{
    public interface IStudentService
    {
        Task<Student?> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task AddStudentAsync(Student student);
        Task DeleteStudentAsync(int Id);
        Task EditStudentAsync(Student student);

    }
}
