using AutoMapper;
using AutoMapper.QueryableExtensions;
using TestTask.Backend.Args;
using TestTask.Backend.DTO;
using TestTask.Backend.Extensions;
using TestTask.Backend.Models;

namespace TestTask.Backend.Services
{
    public class PatientsService : IPatientsService
    {
        private readonly TestTaskContext _context;
        private readonly IMapper _mapper;

        public PatientsService(
            TestTaskContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<PatientTableView> ReadPage(PatientArgs args)
        {
            var patients = _context.Patients.AsQueryable()
            .OrderByColumn(args)
            .GetPage(args)
            .ProjectTo<PatientTableView>(_mapper.ConfigurationProvider)
            .ToList();

            return patients;
        }

        public PatientDTO? ReadByID(int patientId)
        {
            var patient = _context.Patients.Find(patientId);
            return _mapper.Map<PatientDTO>(patient);
        }

        public PatientDTO Create(PatientDTO source)
        {
            var patient = _mapper.Map<Patient>(source);
            var entry = _context.Patients.Add(patient);
            _context.SaveChanges();

            return _mapper.Map<PatientDTO>(entry.Entity);
        }

        public PatientDTO? Update(int patientId, PatientDTO source)
        {
            var doc = _context.Patients.Find(patientId);

            if (doc == null) return null;

            var patient = _mapper.Map<Patient>(source);
            var entry = _context.Entry(doc);
            entry.CurrentValues.SetValues(patient);
            _context.SaveChanges();

            return _mapper.Map<PatientDTO>(entry.Entity);
        }

        public bool Delete(int patientId)
        {
            var doc = _context.Patients.Find(patientId);

            if (doc == null) return false;

            _context.Patients.Remove(doc);
            return _context.SaveChanges() > 0;
        }
    }
}
