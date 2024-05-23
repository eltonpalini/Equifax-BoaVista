using Domain;

namespace Application.Interfaces
{
    public interface ICourseService
    {
        Task AddAsync(Course course);
        Task<Course?> UpdateAsync(int id, Course course);
        Task<Course?> DeleteAsync(int id);
        Task<IList<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
    }
}
