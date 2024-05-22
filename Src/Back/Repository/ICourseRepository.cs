using Domain;

namespace Repository
{
    public interface ICourseRepository
    {
        Task<Course?> GetByIdAsync(int id);
        Task<IList<Course>> GetAllAsync();
        Task SaveAsync(Course course);
    }
}
