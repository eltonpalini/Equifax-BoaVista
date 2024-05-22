using Domain;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(Student student);
        Task<IList<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
    }
}
