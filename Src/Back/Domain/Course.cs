using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public BillingTypeEnum BillingType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public Course(string name, decimal price, BillingTypeEnum billingType) 
        { 
            Name = name;
            Price = price;
            BillingType = billingType;
            CreatedAt = DateTime.UtcNow;
        }

        public void Inativate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
