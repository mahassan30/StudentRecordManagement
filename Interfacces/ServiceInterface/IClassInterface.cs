using DomainModels;

namespace Interfacces.ServiceInterface
{
    public interface IClassInterface
    {
        public IEnumerable<Class> GetAllClasses();
        public Class FindById(int classId);
        void AddClass(Class class1);
        void Update(Class class1);
        void Delete(int classId);
    }
}
