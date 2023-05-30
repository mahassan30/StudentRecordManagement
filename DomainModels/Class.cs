namespace DomainModels
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? ClassRoom { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
