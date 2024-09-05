namespace TestTask.Backend.Args
{
    public class DoctorArgs : IPageArgs, IOrderedArgs
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
    }
}
