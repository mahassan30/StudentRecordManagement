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

            //var studentDataAccess = new StudentDataAccess();
            //var studentList = studentDataAccess.GetStudentList();
            return View(students);
        }

        public ActionResult<Student> Create(int? id)
        {
            var viewModel = new CreateStudentViewModel();

            //viewModel.Classes = dbContext.Classes.ToList();
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
            var studentDataAccess = new StudentDataAccess();
            if (student.StudentId > 0)
            {
                dbContext.Update(student);
                //var updateStudent = studentDataAccess.UpdateStudent(student);
            }
            else
            {
                dbContext.Add(student);
            }
            //var saveStudent = studentDataAccess.SaveStudent(student);

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
