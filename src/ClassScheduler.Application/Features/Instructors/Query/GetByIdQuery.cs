using ClassScheduler.Application.Contracts.ResponseDtos.InstructorResponseDts;
using ClassScheduler.Application.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Instructors.Query;
public record GetInstructorQuery(Guid Id) : IRequest<ErrorOr<InstructorResponseDto>> { }

public class GetInstructorQueryHandler : IRequestHandler<GetInstructorQuery, ErrorOr<InstructorResponseDto>>
{
    private readonly IInstructorRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetInstructorQueryHandler(IInstructorRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<InstructorResponseDto>> Handle(GetInstructorQuery query, CancellationToken cancellationToken)
    {
        var response = new InstructorResponseDto();
        var student = await _studentRepository.GetAsync(query.Id);
        if (student is not null)
        {
            response = _mapper.Map<InstructorResponseDto>(student);
        }

        return response;
    }
}