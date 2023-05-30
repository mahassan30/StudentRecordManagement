using DataAccessLayer.MyModels;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using StudentRecordManagement.DataAccess;
using StudentRecordManagement.ViewModels.Student;
using Student = WebModels.Models.Student;


namespace StudentRecordManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRecordContext dbContext;

        public StudentController(StudentRecordContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var students = dbContext.Students.Select(x=> x.ConvertToWebModel()).ToList();
            return View(students);
        }

        public ActionResult<Student> Create(int? id)
        {
            var viewModel = new CreateStudentViewModel();

            viewModel.Classes = dbContext.Classes.Select(x=>x.ConvertToWebModel()).ToList();
            if (id == null)
            {
                viewModel.Student = new Student();
                return View(viewModel);
            }

            viewModel.Student = dbContext.Students.Find(id.Value).ConvertToWebModel();
            return View(viewModel);


        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            var studentToSave = student.ConvertToDomainModel();
            if (student.StudentId > 0)
            {
                dbContext.Update(studentToSave);
            }
            else
            {
                dbContext.Add(studentToSave);
            }

            dbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult Delete(int id)
        {
            var studentToDelete = dbContext.Students.Find(id);
            dbContext.Remove(studentToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
