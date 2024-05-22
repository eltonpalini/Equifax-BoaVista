using Application.Interfaces;
using Domain;
using Repository;


namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task AddAsync(Course course)
        {
            await _courseRepository.SaveAsync(course);
        }

        public async Task DeleteAsync(Course course)
        {
            course.Inativate();
            await _courseRepository.SaveAsync(course);
        }

        public async Task<IList<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Course course)
        {
            course.UpdatedAt = DateTime.UtcNow;
            await _courseRepository.SaveAsync(course);
        }

    }
}
