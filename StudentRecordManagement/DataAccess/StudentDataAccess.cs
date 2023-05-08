using StudentRecordManagement.Models;
using System.Data.SqlClient;

namespace StudentRecordManagement.DataAccess
{
    public class StudentDataAccess
    {
        public List<Student> GetStudentList()
        {
            var studentList = new List<Student>();

            // Sql Connection
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=StudentRecord;User Id=sa;Password=p@ssw0rd; MultipleActiveResultSets=true");
            connection.Open();
            //Sql Command
            SqlCommand command = new SqlCommand("Select st.StudentId, st.StudentFirstName, st.StudentMiddleName, st.StudentLastName, st.StudentAddress, st.StudentPhone from Student st", connection);

            //Sql Reader
            SqlDataReader reader = command.ExecuteReader();

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
                    //ClassName = reader["ClassName"].ToString()
                };
                studentList.Add(student);
            }
            return studentList;
        }

        public Student GetStudent(int studentId)
        {
            var studentList = new List<Student>();

            // Sql Connection
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=StudentRecord;User Id=sa;Password=p@ssw0rd; MultipleActiveResultSets=true");
            connection.Open();
            //Sql Command
            SqlCommand command = new SqlCommand("Select st.StudentId, st.StudentFirstName, st.StudentMiddleName, st.StudentLastName, st.StudentAddress, st.StudentPhone from Student st where st.StudentId =" + studentId, connection);

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
                };
                studentList.Add(student);
            }
            return studentList.FirstOrDefault();
        }

        public int SaveStudent(Student student)
        {
            var studentList = new List<Student>();

            // Sql Connection
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=StudentRecord;User Id=sa;Password=p@ssw0rd; MultipleActiveResultSets=true");
            connection.Open();

            string query =
                "Insert into Student (StudentFirstName, StudentMiddleName, StudentLastName, StudentPhone, StudentAddress) values (@sfName, @smName, @slName, @sPhone, @sAddress)";
             ////Sql Command
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@sfName", student.FirstName);
            command.Parameters.AddWithValue("@smName", student.MiddleName);
            command.Parameters.AddWithValue("@slName", student.LastName);
            command.Parameters.AddWithValue("@sPhone", student.Phone);
            command.Parameters.AddWithValue("@sAddress", student.Address);
            ////Sql Reader
            return command.ExecuteNonQuery();
        }
    }
}
