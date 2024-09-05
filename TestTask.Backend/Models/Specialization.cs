using System;
using System.Collections.Generic;

namespace TestTask.Backend.Models;

public partial class Specialization
{
    public int SpecId { get; set; }

    public string SpecName { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
