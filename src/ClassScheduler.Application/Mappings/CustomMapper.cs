using ClassScheduler.Application.Contracts.RequestDtos.CourseRequestDtos;
using ClassScheduler.Application.Contracts.RequestDtos.DepartmentRequestDtos;
using ClassScheduler.Application.Contracts.RequestDtos.RoleRequestDtos;
using ClassScheduler.Application.Contracts.RequestDtos.RoomRequestDtos;
using ClassScheduler.Application.Contracts.RequestDtos.StudentRequestDts;
using ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.InstructorResponseDts;
using ClassScheduler.Application.Contracts.ResponseDtos.RoomResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.StudentResponseDts;
using ClassScheduler.Domain.Model.Entities;
using Mapster;

namespace ClassScheduler.Application.Mappings
{
    public class CustomMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<StudentRequestDto, Student>();
            config.NewConfig<Student, StudentResponseDto>();
            config.NewConfig<DepartmentRequestDto, Department>();
            config.NewConfig<Department, DepartmentResponseDto>();
            config.NewConfig<List<Department>, List<DepartmentResponseDto>>();
            config.NewConfig<CourseRequestDto, Course>();
            config.NewConfig<Course, CourseResponseDto>();
            config.NewConfig<EditDepartmentRequestDto, Department>();
            config.NewConfig<EditRoomRequestDto, Room>();
            config.NewConfig<List<Room>, List<RoomResponseDto>>();
            config.NewConfig<List<Instructor>, List<InstructorResponseDto>>();
        }
    }
}
