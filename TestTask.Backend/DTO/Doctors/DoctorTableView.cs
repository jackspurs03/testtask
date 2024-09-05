namespace TestTask.Backend.DTO
{
    public class DoctorTableView
    {
        public int DoctorId { get; set; }

        public string Fio { get; set; } = null!;

        public int CabinetNumber { get; set; }

        public string SpecName { get; set; } = null!;

        public string AreaName { get; set; } = null!;
    }
}
