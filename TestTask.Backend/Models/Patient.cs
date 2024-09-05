using System;
using System.Collections.Generic;

namespace TestTask.Backend.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Fathername { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public byte Sex { get; set; }

    public int AreaId { get; set; }

    public virtual Area Area { get; set; } = null!;
}
