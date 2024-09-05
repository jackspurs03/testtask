using TestTask.Backend.Args;
using TestTask.Backend.DTO;

namespace TestTask.Backend.Services
{
    public interface IPatientsService
    {
        IEnumerable<PatientTableView> ReadPage(PatientArgs args);
        PatientDTO? ReadByID(int patientId);
        PatientDTO Create(PatientDTO source);
        PatientDTO? Update(int patientId, PatientDTO source);
        bool Delete(int patientId);
    }
}
