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

        public async Task<Course?> DeleteAsync(int id)
        {
            var _course = await _courseRepository.GetByIdAsync(id);

            if (_course is null)
                return default;

            _course.Inativate();
            await _courseRepository.SaveAsync(_course);

            return _course;
        }

        public async Task<IList<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<Course?> UpdateAsync(int id, Course course)
        {
            var _course = await _courseRepository.GetByIdAsync(id);

            if (_course is null)
                return default;

            _course.Update(course.Name, course.Price, course.BillingType);
            await _courseRepository.SaveAsync(_course);

            return _course;
        }

    }
}
