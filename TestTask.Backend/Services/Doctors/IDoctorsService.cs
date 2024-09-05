using TestTask.Backend.Args;
using TestTask.Backend.DTO;
using TestTask.Backend.Models;

namespace TestTask.Backend.Services
{
    public interface IDoctorsService
    {
        IEnumerable<DoctorTableView> ReadPage(DoctorArgs args);
        DoctorDTO? ReadByID(int doctorId);
        DoctorDTO Create(DoctorDTO source);
        DoctorDTO? Update(int doctorId, DoctorDTO source);
        bool Delete(int doctorId);
    }
}
