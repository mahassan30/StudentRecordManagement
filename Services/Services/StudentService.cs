using DomainModels;
using Interfacces.RepositoryInterface;
using Interfacces.ServiceInterface;

namespace Services.Services
{
    public class StudentService : IStudentInterface
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public IEnumerable<Student> GetAll()
        {
           return studentRepository.GetAll();
        }

        public Student FindById(int studentId)
        {
            return studentRepository.FindById(studentId);
        }

        public void AddStudent(Student student)
        {
            studentRepository.Add(student);
            studentRepository.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var studentToDelete = studentRepository.FindById(studentId);
            studentRepository.Delete(studentToDelete);
            studentRepository.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            studentRepository.Update(student);
            studentRepository.SaveChanges();
        }
    }
}
