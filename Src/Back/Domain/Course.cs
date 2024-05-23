using Domain.Enums;

namespace Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int BillingType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public Course() { }

        public Course(string name, decimal price, BillingTypeEnum billingType) 
        { 
            Name = name;
            Price = price;
            BillingType = (int)billingType;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public void Inativate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(string name, decimal price, int  billingType)
        {
            Name = name; 
            Price = price;
            BillingType = billingType;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
