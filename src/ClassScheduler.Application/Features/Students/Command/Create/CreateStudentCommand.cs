using ClassScheduler.Application.Contracts.RequestDtos.StudentRequestDts;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Students.Command.Create;
public record CreateStudentCommand(StudentRequestDto StudentRequestDto) : IRequest<ErrorOr<ServiceResponse<int>>>{}

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, ErrorOr<ServiceResponse<int>>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<ServiceResponse<int>>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        var validator = new CreateStudentCommandValidator(request);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid)
        {
            var studentEntity = _mapper.Map<Student>(request.StudentRequestDto);
            response.Success = await _studentRepository.CreateStudentAsync(studentEntity);
            if (response.Success)
            {
                response.Data = 1;
                response.Message = "Successfully created a student!";
            }
            else response.Errors!.Add("Could not Create Stuent entity");
        }

        return response;
    }
}