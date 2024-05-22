using Domain;

namespace Application.Interfaces
{
    public interface ICourseService
    {
        Task AddAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(Course course);
        Task<IList<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
    }
}
