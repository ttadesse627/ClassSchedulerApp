using ClassScheduler.Application.Contracts.ResponseDtos.StudentResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Students.Query;
public record GetStudentQuery(Guid Id) : IRequest<ErrorOr<StudentResponseDto>> { }

public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, ErrorOr<StudentResponseDto>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<StudentResponseDto>> Handle(GetStudentQuery query, CancellationToken cancellationToken)
    {
        var response = new StudentResponseDto();
        var student = await _studentRepository.GetAsync(query.Id);
        if (student is not null)
        {
            response = _mapper.Map<StudentResponseDto>(student);
        }

        return response;
    }
}