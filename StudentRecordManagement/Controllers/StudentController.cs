using DataAccessLayer.MyModels;
using Interfacces.ServiceInterface;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using StudentRecordManagement.DataAccess;
using StudentRecordManagement.ViewModels.Student;
using Student = WebModels.Models.Student;


namespace StudentRecordManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentInterface studentInterface;
        private readonly IClassInterface classInterface;

        public StudentController(IStudentInterface studentInterface, IClassInterface classInterface)
        {
            this.studentInterface = studentInterface;
            this.classInterface = classInterface;
        }

        public IActionResult Index()
        {
            var students = studentInterface.GetAll().Select(x=> x.ConvertToWebModel()).ToList();
            return View(students);
        }

        public ActionResult<Student> Create(int? id)
        {
            var viewModel = new CreateStudentViewModel();

            viewModel.Classes = classInterface.GetAllClasses().Select(x => x.ConvertToWebModel()).ToList();
            if (id == null)
            {
                viewModel.Student = new Student();
                return View(viewModel);
            }

            viewModel.Student = studentInterface.FindById(id.Value).ConvertToWebModel();
            return View(viewModel);


        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            var studentToSave = student.ConvertToDomainModel();
            if (student.StudentId > 0)
            {
                studentInterface.UpdateStudent(studentToSave);
            }
            else
            {
                studentInterface.AddStudent(studentToSave);
            }

            return RedirectToAction("Index");
            
        }

        public ActionResult Delete(int id)
        {
            studentInterface.DeleteStudent(id);
            return RedirectToAction("Index");

        }
    }
}
