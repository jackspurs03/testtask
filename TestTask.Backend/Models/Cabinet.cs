using System;
using System.Collections.Generic;

namespace TestTask.Backend.Models;

public partial class Cabinet
{
    public int CabinetId { get; set; }

    public int CabinetNumber { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
