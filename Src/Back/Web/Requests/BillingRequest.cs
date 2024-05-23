namespace Web.Requests
{
    public class BillingRequest
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentTypeId { get; set; }
    }
}
