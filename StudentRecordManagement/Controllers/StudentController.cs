using Microsoft.AspNetCore.Mvc;
using StudentRecordManagement.Models;
using System.Data;
using System.Data.SqlClient;
using StudentRecordManagement.DataAccess;

namespace StudentRecordManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDataAccess _studentDataAccess;

        public StudentController()
        {
            
        }

        public IActionResult Index()
        {
            var studentDataAccess = new StudentDataAccess();
            var studentList = studentDataAccess.GetStudentList();
            return View(studentList);
        }

        public ActionResult<Student> Create(int? id)
        {

            if (id == null)
            {
                var student = new Student();
                return View(student);
            }
            else
            {
                var dataAccess = new StudentDataAccess();
                var studentFromDb = dataAccess.GetStudent(id.Value);
                return View(studentFromDb);
            }


        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            var studentDataAccess = new StudentDataAccess();
            var abc = studentDataAccess.SaveStudent(student);
            return RedirectToAction("Index");
        }
    }
}
