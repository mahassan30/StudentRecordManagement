using Microsoft.AspNetCore.Mvc;
using StudentRecordManagement.Models;
using System.Data;
using System.Data.SqlClient;
using StudentRecordManagement.DataAccess;

namespace StudentRecordManagement.Controllers
{
    public class StudentController : Controller
    {
        public StudentController()
        {
       
        }

        public IActionResult Index()
        {
            var studentList = new List<Student>();

            // Sql Connection
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=StudentRecord;User Id=sa;Password=p@ssw0rd; MultipleActiveResultSets=true");
            connection.Open();
            //Sql Command
            SqlCommand command = new SqlCommand("Select st.StudentId, st.StudentFirstName, st.StudentMiddleName, st.StudentLastName, st.StudentAddress, st.StudentPhone, cl.ClassName from Student st join Classes cl on st.ClassId  = cl.ClassId", connection);

            //Sql Reader
            SqlDataReader reader = command.ExecuteReader();

            ////Sql DataSet
            //DataSet dataset = new DataSet();

            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //adapter.Fill(dataset);

            while (reader.Read())
            {
                var student = new Student
                {
                    StudentId = (int)reader["StudentId"],
                    FirstName = reader["StudentFirstName"].ToString(),
                    MiddleName = reader["StudentMiddleName"].ToString(),
                    LastName = reader["StudentLastName"].ToString(),
                    Address = reader["StudentAddress"].ToString(),
                    Phone = reader["StudentPhone"].ToString(),
                    ClassName = reader["ClassName"].ToString()
                };
                studentList.Add(student);
            }
            connection.Close();
            var student1 = new Student();
            return View(studentList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
