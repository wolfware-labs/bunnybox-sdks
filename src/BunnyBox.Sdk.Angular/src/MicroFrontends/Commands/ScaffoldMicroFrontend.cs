using BunnyBox.Sdk.Projects;
using MediatR;

namespace BunnyBox.Sdk.Angular.MicroFrontends.Commands;

internal sealed record ScaffoldMicroFrontend(ScaffoldRequest Details) : IRequest<ScaffoldResponse>;

internal sealed class ScaffoldMicroFrontendHandler : IRequestHandler<ScaffoldMicroFrontend, ScaffoldResponse>
{
  public Task<ScaffoldResponse> Handle(ScaffoldMicroFrontend request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
