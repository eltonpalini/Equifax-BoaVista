using Domain;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        Task AddAsync(Student student);
        Task<Student?> UpdateAsync(int id, Student student);
        Task<Student?> DeleteAsync(int id);
        Task<IList<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
    }
}
