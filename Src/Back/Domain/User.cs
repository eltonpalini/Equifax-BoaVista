namespace Domain
{
    public class User
    {
        public int Id { get; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public User() { }        

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void Inactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(string login, string password)
        {
            Login = login;
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
