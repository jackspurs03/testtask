using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TestTask.Backend.Args;
using TestTask.Backend.DTO;
using TestTask.Backend.Extensions;
using TestTask.Backend.Models;

namespace TestTask.Backend.Services
{
    public class DoctorsService : IDoctorsService
    {
        private readonly TestTaskContext _context;
        private readonly IMapper _mapper;

        public DoctorsService(
            TestTaskContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<DoctorTableView> ReadPage(DoctorArgs args)
        {
            var doctors = _context.Doctors.AsQueryable()
            .OrderByColumn(args)
            .GetPage(args)
            .ProjectTo<DoctorTableView>(_mapper.ConfigurationProvider)
            .ToList();

            return doctors;
        }

        public DoctorDTO? ReadByID(int doctorId)
        {
            var doctor = _context.Doctors.Find(doctorId);
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public DoctorDTO Create(DoctorDTO source)
        {
            var doctor = _mapper.Map<Doctor>(source);
            var entry = _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return _mapper.Map<DoctorDTO>(entry.Entity);
        }

        public DoctorDTO? Update(int doctorId, DoctorDTO source)
        {
            var doc = _context.Doctors.Find(doctorId);

            if (doc == null) return null; 

            var doctor = _mapper.Map<Doctor>(source);
            var entry = _context.Entry(doc);
            entry.CurrentValues.SetValues(doctor);
            _context.SaveChanges();

            return _mapper.Map<DoctorDTO>(entry.Entity);
        }

        public bool Delete(int doctorId)
        {
            var doc = _context.Doctors.Find(doctorId);

            if (doc == null) return false;

            _context.Doctors.Remove(doc);
            return _context.SaveChanges() > 0;
        }
    }
}
