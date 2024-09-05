namespace TestTask.Backend.DTO
{
    public class PatientDTO
    {
        public int PatientId { get; set; }

        public string Surname { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Fathername { get; set; } = null!;

        public DateOnly Birthdate { get; set; }

        public byte Sex { get; set; }

        public int AreaId { get; set; }
    }
}
