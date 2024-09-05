namespace TestTask.Backend.DTO
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }

        public string Fio { get; set; } = null!;

        public int CabinetId { get; set; }

        public int SpecId { get; set; }

        public int? AreaId { get; set; }
    }
}
