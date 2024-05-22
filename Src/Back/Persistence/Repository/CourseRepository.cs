using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Persistence.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Context _context;

        public CourseRepository(Context context)
        {
            _context = context;
        }

        public async Task<IList<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task SaveAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }
    }
}
