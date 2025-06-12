using BunnyBox.Sdk.Projects;
using MediatR;

namespace BunnyBox.Sdk.Angular.MicroFrontends.Commands;

internal sealed record RunMicroFrontend(RunRequest Details) : IRequest<RunResponse>;

internal sealed class RunMicroFrontendHandler : IRequestHandler<RunMicroFrontend, RunResponse>
{
  public Task<RunResponse> Handle(RunMicroFrontend request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
