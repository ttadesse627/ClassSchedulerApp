using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Departments.Query;
public record GetForCourseQuery : IRequest<ServiceResponse<List<GetForCourseDto>>> { }
public class GetForCourseQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper) : IRequestHandler<GetForCourseQuery, ServiceResponse<List<GetForCourseDto>>>
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ServiceResponse<List<GetForCourseDto>>> Handle(GetForCourseQuery request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<List<GetForCourseDto>>();
        var departments = await _departmentRepository.GetForCourseAsync();
        if (departments.Count > 0)
        {
            var studentDtos = _mapper.Map<List<GetForCourseDto>>(departments);
            response.Data = studentDtos;
        }
        return response;
    }
}