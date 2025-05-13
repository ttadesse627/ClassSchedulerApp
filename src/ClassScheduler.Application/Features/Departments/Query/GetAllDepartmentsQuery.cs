using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Departments.Query;
public record GetAllDepartmentsQuery : IRequest<ServiceResponse<List<DepartmentResponseDto>>> { }
public class GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper) : IRequestHandler<GetAllDepartmentsQuery, ServiceResponse<List<DepartmentResponseDto>>>
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ServiceResponse<List<DepartmentResponseDto>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<List<DepartmentResponseDto>>();
        var students = await _departmentRepository.GetAllAsync();
        if (students.Count > 0)
        {
            var studentDtos = _mapper.Map<List<DepartmentResponseDto>>(students);
            response.Data = studentDtos;
        }
        return response;
    }
}