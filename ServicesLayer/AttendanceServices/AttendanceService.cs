using DomainLayer.Models.Attendance;
using InfrastructureLayer.DataAccess.Repositories;

namespace ServicesLayer.AttendanceServices
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(IAttendanceModel attendanceModel)
        {
            _unitOfWork.attendanceRepository.Add(attendanceModel);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int attendanceId)
        {
            var attendance = _unitOfWork.attendanceRepository.Get(a => a.Id == attendanceId);
            _unitOfWork.attendanceRepository.Remove(attendance);
            _unitOfWork.SaveChanges();
        }

        public ICollection<IAttendanceModel> GetAttendanceModel()
        {
            var attendances = _unitOfWork.attendanceRepository.GetAll();
            return attendances.ToList();
        }

        public void Update(IAttendanceModel attendanceModel)
        {
            _unitOfWork.attendanceRepository.Update(attendanceModel);
            _unitOfWork.SaveChanges();
        }

        public void ValidateModel(IAttendanceModel attendanceModel)
        {
            throw new NotImplementedException();
        }
    }
}
