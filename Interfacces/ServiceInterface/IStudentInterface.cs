using DomainModels;

namespace Interfacces.ServiceInterface
{
    public interface IStudentInterface
    {
        public IEnumerable<Student> GetAll();
        public Student FindById(int studentId);
        void AddStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
    }
}
