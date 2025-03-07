using System;
using System.Collections.Generic;

namespace RazorPageLab.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
