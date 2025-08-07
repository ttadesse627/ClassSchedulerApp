using ClassScheduler.Application.Contracts.RequestDtos.InstructorRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Instructors.Command.Create;
public record CreateInstructorCommand(InstructorRequestDto InstructorRequestDto) : IRequest<ServiceResponse<int>> { }

public class CreateInstructorCommandHandler(IInstructorRepository instructorRepository, IMapper mapper, ICourseRepository courseRepository) : IRequestHandler<CreateInstructorCommand, ServiceResponse<int>>
{
    private readonly IInstructorRepository _instructorRepository = instructorRepository;
    private readonly ICourseRepository _courseRepository = courseRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<ServiceResponse<int>> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        var validator = new CreateInstructorCommandValidator(request);
        List<Course> courses = [];
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            if (request.InstructorRequestDto.CourseIds.Count > 0)
            {
                courses = await _courseRepository.GetByIdsAsync(request.InstructorRequestDto.CourseIds.ToList());
            }
            var instructorEntity = new Instructor
            {
                Person = new Person
                {
                    FirstName = request.InstructorRequestDto.FirstName,
                    MiddleName = request.InstructorRequestDto.MiddleName,
                    LastName = request.InstructorRequestDto.LastName,
                    BirthDate = request.InstructorRequestDto.BirthDate,
                },
                Courses = courses
            };
            response.Success = await _instructorRepository.CreateAsync(instructorEntity);
            if (response.Success)
            {
                response.Data = 1;
                response.Message = "Successfully created a instructor!";
            }
            else response.Errors.Add("Could not Create Instructor entity");
        }

        return response;
    }
}