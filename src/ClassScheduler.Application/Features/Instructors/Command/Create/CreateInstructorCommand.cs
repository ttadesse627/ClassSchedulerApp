using ClassScheduler.Application.Contracts.RequestDtos.InstructorRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Instructors.Command.Create;
public record CreateInstructorCommand(InstructorRequestDto InstructorRequestDto) : IRequest<ErrorOr<ServiceResponse<int>>> { }

public class CreateInstructorCommandHandler(IInstructorRepository instructorRepository, IMapper mapper) : IRequestHandler<CreateInstructorCommand, ErrorOr<ServiceResponse<int>>>
{
    private readonly IInstructorRepository _instructorRepository = instructorRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<ErrorOr<ServiceResponse<int>>> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        var validator = new CreateInstructorCommandValidator(request);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var instructorEntity = _mapper.Map<Instructor>(request.InstructorRequestDto);
            response.Success = await _instructorRepository.CreateAsync(instructorEntity);
            if (response.Success)
            {
                response.Data = 1;
                response.Message = "Successfully created a instructor!";
            }
            else response.Errors!.Add("Could not Create Instructor entity");
        }

        return response;
    }
}