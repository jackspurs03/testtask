using System;
using System.Collections.Generic;

namespace TestTask.Backend.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string Fio { get; set; } = null!;

    public int CabinetId { get; set; }

    public int SpecId { get; set; }

    public int? AreaId { get; set; }

    public virtual Area? Area { get; set; }

    public virtual Cabinet Cabinet { get; set; } = null!;

    public virtual Specialization Spec { get; set; } = null!;
}
