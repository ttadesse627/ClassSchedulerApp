using ClassScheduler.Application.Contracts.ResponseDtos.InstructorResponseDts;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Instructors.Query;
public record GetListQuery() : IRequest<List<InstructorsResponseDto>> { }

public class GetInstructorsQueryHandler(IInstructorRepository instructorRepository, IMapper mapper) : IRequestHandler<GetListQuery, List<InstructorsResponseDto>>
{
    private readonly IInstructorRepository _instructorRepository = instructorRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<InstructorsResponseDto>> Handle(GetListQuery query, CancellationToken cancellationToken)
    {
        var instructorDtos = new List<InstructorsResponseDto>();
        var instructors = await _instructorRepository.GetListAsync();
        if (instructors.Count > 0)
        {
            foreach (Instructor instructor in instructors)
            {
                instructorDtos.Add(
                    new InstructorsResponseDto
                    {
                        Id = instructor.Id,
                        FirstName = instructor.PersonInfo?.FirstName,
                        MiddleName = instructor.PersonInfo?.MiddleName,
                        LastName = instructor.PersonInfo?.LastName,
                        NumberOfAssignedCourses = instructor.Courses.Count
                    }
                );
            }
        }

        return instructorDtos;
    }
}