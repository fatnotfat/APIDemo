namespace Health360Scheduler.DataTransferObjects
{
    public class DoctorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string PhoneNumber { get; set; }
        public Guid AccountId { get; set; }
    }
}
