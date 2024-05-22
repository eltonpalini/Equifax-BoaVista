using Domain;

namespace Repository
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(int id);
        Task<IList<Student>> GetAllAsync();
        Task SaveAsync(Student student);
    }
}
