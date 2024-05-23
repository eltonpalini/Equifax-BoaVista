using Domain.Enums;

namespace Domain
{
    public class Billing
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public decimal Amount { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public Billing() { }

        public Billing(Student student, Course course, PaymentTypeEnum paymentType)
        {
            Student = student;
            Course = course;
            PaymentType = paymentType;
            CreatedAt = DateTime.UtcNow;
        }

        public void Inactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(int studentId, int courseId, int paymentType, decimal amount)
        {
            StudentId = studentId;
            CourseId = courseId;
            PaymentTypeId = paymentType;
            Amount = amount;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
