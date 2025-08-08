using ClassScheduler.Application.Contracts.ResponseDtos.StudentResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Departments.Query;
public record GetDepartmentQuery(Guid Id) : IRequest<ErrorOr<StudentResponseDto>> { }

public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, ErrorOr<StudentResponseDto>>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public GetDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<StudentResponseDto>> Handle(GetDepartmentQuery query, CancellationToken cancellationToken)
    {
        var response = new StudentResponseDto();
        var departmentEntity = await _departmentRepository.GetAsync(query.Id);
        if (departmentEntity is not null)
        {
            response = _mapper.Map<StudentResponseDto>(departmentEntity);
        }

        return response;
    }
}