using System.ComponentModel.DataAnnotations;

namespace CoreMasterDetails.Models.ViewModels
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; } = null!;
        [Required, Display(Name = "Date of Birth"), DataType(DataType.Date)]
        public DateTime Dob { get; set; } = DateTime.Now;

        public string MobileNo { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsEnrolled { get; set; }

        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int ModuleId { get; set; }

        public string ModuleName { get; set; }

        public int Duration { get; set; }


        public virtual Course Course { get; set; }
        public List<Course> Courses { get; set; }


        public virtual IList<Module> Modules { get; set; } = new List<Module>();

        public IList<Student> Students { get; set; }
        public IFormFile ProfileFile { get; set; }
    }
}
