using Application.Interfaces;
using Domain;
using Repository;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddAsync(Student student)
        {
            await _studentRepository.SaveAsync(student);
        }

        public async Task DeleteAsync(Student student)
        {
            student.Inactivate();
            await _studentRepository.SaveAsync(student);
        }

        public async Task<IList<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentRepository.SaveAsync(student);
        }
    }
}
