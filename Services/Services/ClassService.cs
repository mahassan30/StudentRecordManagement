using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.MyModels;
using DomainModels;
using Interfacces.RepositoryInterface;
using Interfacces.ServiceInterface;

namespace Services.Services
{
    public class ClassService : IClassInterface
    {
        private readonly IClassRepository classRepository;

        public ClassService(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }
        public IEnumerable<Class> GetAllClasses()
        {
            return classRepository.GetAll();
        }

        public Class FindById(int classId)
        {
            return classRepository.FindById(classId);
        }

        public void AddClass(Class class1)
        {
            classRepository.Add(class1);
            classRepository.SaveChanges();
        }

        public void Update(Class class1)
        {
            classRepository.Update(class1);
            classRepository.SaveChanges();
        }

        public void Delete(int classId)
        {
            var classToDelete = classRepository.FindById(classId);
            classRepository.Delete(classToDelete);
            classRepository.SaveChanges();
        }
    }
}
