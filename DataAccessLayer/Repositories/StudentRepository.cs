using DataAccessLayer.MyModels;
using DomainModels;
using Interfacces.RepositoryInterface;

namespace DataAccessLayer.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentRecordContext dbContext) : base(dbContext)
        {
        }
    }
}
