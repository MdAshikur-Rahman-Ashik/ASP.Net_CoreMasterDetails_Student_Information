using System;
using System.Collections.Generic;

namespace CoreMasterDetails.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Mobile { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public bool Enroll { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();
}
