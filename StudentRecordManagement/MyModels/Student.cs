using System;
using System.Collections.Generic;

namespace StudentRecordManagement.MyModels
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; } = null!;
        public string? StudentMiddleName { get; set; }
        public string? StudentLastName { get; set; }
        public string? StudentAddress { get; set; }
        public string? StudentPhone { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
    }
}
