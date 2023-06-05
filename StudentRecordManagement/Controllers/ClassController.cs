using Interfacces.ServiceInterface;
using Mappers;
using Microsoft.AspNetCore.Mvc;

namespace StudentRecordManagement.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassInterface classInterface;

        public ClassController(IClassInterface classInterface)
        {
            this.classInterface = classInterface;
        }

        public IActionResult Index()
        {
            var classes = classInterface.GetAllClasses().Select(x => x.ConvertToWebModel()).ToList();
            return View(classes);
        }

        public ActionResult<WebModels.Models.Class> Create(int? id)
        {
            
            if (id == null)
            {
                var classModel = new WebModels.Models.Class();
                return View(classModel);
            }

            var fromDb = classInterface.FindById(id.Value).ConvertToWebModel();
            return View(fromDb);


        }

        [HttpPost]
        public ActionResult Create(WebModels.Models.Class class1)
        {
            var class1ToSave = class1.ConvertToDomainModel();
            if (class1.ClassId > 0)
            {
                classInterface.Update(class1ToSave);
            }
            else
            {
                classInterface.AddClass(class1ToSave);
            }

            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            classInterface.Delete(id);
            return RedirectToAction("Index");

        }
    }
}
