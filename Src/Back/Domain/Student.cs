namespace Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public Student() { }
        

        public Student(string name, string login, string password)
        {
            Name = name;
            User = new User(login, password);
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void Inactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(string name, string login, string password)
        {
            Name = name;
            User = new User(login, password);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
