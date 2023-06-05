using DataAccessLayer.MyModels;
using DomainModels;
using Interfacces.RepositoryInterface;

namespace DataAccessLayer.Repositories
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(StudentRecordContext dbContext) : base(dbContext)
        {
        }
    }
}
