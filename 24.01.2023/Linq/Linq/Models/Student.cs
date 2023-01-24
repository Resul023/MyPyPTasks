using System;
using System.Collections.Generic;

namespace Linq.Models;

public partial class Student
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? City { get; set; }
}
