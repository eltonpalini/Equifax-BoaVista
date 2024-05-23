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

        public async Task<Student?> DeleteAsync(int id)
        {
            var _student = await _studentRepository.GetByIdAsync(id);

            if (_student is null)
                return default;

            _student.Inactivate();
            await _studentRepository.SaveAsync(_student);

            return _student;
        }

        public async Task<IList<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student?> UpdateAsync(int id, Student student)
        {
            var _student = await _studentRepository.GetByIdAsync(id);

            if (_student is null)
                return default;

            _student.Update(student.Name, student.User.Login, student.User.Password);
            await _studentRepository.SaveAsync(student);

            return _student;
        }
    }
}
