using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Student : User
    {
        public new int Id { get; set; }
        public string Name { get; private set; }
        public new DateTime CreatedAt { get; private set; }
        public new DateTime? UpdatedAt { get; set; }
        public new bool IsActive { get; set; }

        public Student(string name, string login, string password) : base(login, password)
        {
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public new void Inactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
