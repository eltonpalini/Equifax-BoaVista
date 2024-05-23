namespace Web.Requests
{
    public class CourseRequest
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int BillingType { get; set; }

    }
}
