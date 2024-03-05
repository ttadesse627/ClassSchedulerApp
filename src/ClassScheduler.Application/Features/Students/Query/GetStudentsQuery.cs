using ClassScheduler.Application.Contracts.ResponseDtos.StudentResponseDts;
using ClassScheduler.Application.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Students.Query;
public record GetStudentsQuery() : IRequest<ErrorOr<List<StudentResponseDto>>> { }

public class GetStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper) : IRequestHandler<GetStudentsQuery, ErrorOr<List<StudentResponseDto>>>
{
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ErrorOr<List<StudentResponseDto>>> Handle(GetStudentsQuery query, CancellationToken cancellationToken)
    {
        var response = new List<StudentResponseDto>();
        var students = await _studentRepository.GetStudentsListAsync();
        if (students.Count > 0)
        {
            response = _mapper.Map<List<StudentResponseDto>>(students);
        }

        return response;
    }
}