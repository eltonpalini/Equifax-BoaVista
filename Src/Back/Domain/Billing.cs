using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Billing
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }

        public Billing(Student student, Course course, PaymentTypeEnum paymentType)
        {
            Student = student;
            Course = course;
            PaymentType = paymentType;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
