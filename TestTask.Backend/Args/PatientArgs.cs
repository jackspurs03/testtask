namespace TestTask.Backend.Args
{
    public class PatientArgs : IPageArgs, IOrderedArgs
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
    }
}
