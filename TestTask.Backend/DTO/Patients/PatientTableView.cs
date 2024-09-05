namespace TestTask.Backend.DTO
{
    public class PatientTableView
    {
        public int PatientId { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Fathername { get; set; } = null!;

        public DateOnly Birthdate { get; set; }

        public string Sex { get; set; } = null!;

        public string AreaName { get; set; } = null!;
    }
}
