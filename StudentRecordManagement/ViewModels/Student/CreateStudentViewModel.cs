using DataAccessLayer.MyModels;
using WebModels.Models;

namespace StudentRecordManagement.ViewModels.Student
{
    public class CreateStudentViewModel
    {
        public CreateStudentViewModel()
        {
            Student = new WebModels.Models.Student();
            Classes = new List<Class>();
        }

        public WebModels.Models.Student Student { get; set; }
        public List<Class> Classes { get; set; }    
    }
}
