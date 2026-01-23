using MediatR;

namespace LogicalFitness.Application.Commands.Common;

public abstract record BaseCommand<TResponse> : IRequest<TResponse>
{

}
