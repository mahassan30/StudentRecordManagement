using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using StudentRecordManagement.DataAccess;
using StudentRecordManagement.MyModels;
using Student = StudentRecordManagement.Models.Student;

namespace StudentRecordManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRecordContext dbContext;
        private readonly StudentDataAccess _studentDataAccess;

        public StudentController(StudentRecordContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var students = dbContext.Students.ToList();

            //var studentDataAccess = new StudentDataAccess();
            //var studentList = studentDataAccess.GetStudentList();
            return View(students);
        }

        public ActionResult<Student> Create(int? id)
        {

            if (id == null)
            {
                var student = new MyModels.Student();
                return View(student);
            }

            //var dataAccess = new StudentDataAccess();
            //var studentFromDb = dataAccess.GetStudent(id.Value);

            var studentToReturn = dbContext.Students.Find(id.Value);
            return View(studentToReturn);


        }

        [HttpPost]
        public ActionResult Create(MyModels.Student student)
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
            //var studentDataAccess = new StudentDataAccess();
            //var deleteStudent = studentDataAccess.DeleteStudent(id);
            var studentToDelete = dbContext.Students.Find(id);
            dbContext.Remove(studentToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
