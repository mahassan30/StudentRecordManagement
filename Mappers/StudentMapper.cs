using DomainModels;

namespace Mappers
{
    public static class StudentMapper
    {
        public static WebModels.Models.Student ConvertToWebModel(this Student source)
        {
            return new WebModels.Models.Student
            {
                StudentId = source.StudentId,
                StudentFullName = source.StudentFirstName + " " + source.StudentMiddleName + " " +
                                  source.StudentLastName,
                FirstName = source.StudentFirstName,
                MiddleName = source.StudentMiddleName,
                LastName = source.StudentLastName,
                Address = source.StudentAddress,
                Phone = source.StudentPhone,
                ClassName = source.Class?.ClassName
            };
        }

        public static Student ConvertToDomainModel(this WebModels.Models.Student source)
        {
            return new Student
            {
                StudentFirstName = source.FirstName,
                StudentMiddleName = source.MiddleName,
                StudentLastName = source.LastName,
                StudentAddress = source.Address,
                StudentPhone = source.Phone,
                ClassId = source.ClassId
            };
        }

        public static WebModels.Models.Student ConvertForDropdown(Student source)
        {
            return new WebModels.Models.Student
            {
                StudentId = source.StudentId,
                StudentFullName = source.StudentFirstName + " " + source.StudentMiddleName + " " +
                                  source.StudentLastName
            };
        }

    }
}
