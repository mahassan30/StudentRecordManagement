namespace WebModels.Models
{
    public class Student
    {
        public int StudentId { get; set; } //Need to go through what is Getter Setter.
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? ClassName { get; set; }
        public int? ClassId { get; set; }
        public string StudentFullName { get; set; }

        public Class Class { get; set; }
    }
}
