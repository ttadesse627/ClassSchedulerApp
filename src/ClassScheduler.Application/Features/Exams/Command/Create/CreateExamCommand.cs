using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Exams.Command.Create;
public record CreateExamCommand: IRequest<ServiceResponse<int>>{
    public required string Name { get; set; }
    public double OutOf { get; set; }
    public string? Remark { get; set; }
}
public class CreateExamCommandHandler(IExamRepository ExamRepository): IRequestHandler<CreateExamCommand, ServiceResponse<int>>
{
    private readonly IExamRepository _ExamRepository = ExamRepository;

    public async Task<ServiceResponse<int>> Handle(CreateExamCommand command, CancellationToken cancellationToken)
    {
        Exam Exam = new()
        {
            Name = command.Name,
            OutOf = command.OutOf,
            Remark = command.Remark
        };
        var response = await _ExamRepository.Create(Exam, cancellationToken);
        return response;
    }
}