using Domain;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Persistence.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Context _context;

        public StudentRepository(Context context)
        {
            _context = context;
        }

        public async Task<IList<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task SaveAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }
}
