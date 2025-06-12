using Wolfware.BunnyBox.Sdk.Projects;
using MediatR;

namespace Wolfware.BunnyBox.Sdk.Angular.MicroFrontends.Commands;

internal sealed record BuildMicroFrontend(BuildRequest Details) : IRequest<BuildResponse>;

internal sealed class BuildMicroFrontendHandler : IRequestHandler<BuildMicroFrontend, BuildResponse>
{
  public Task<BuildResponse> Handle(BuildMicroFrontend request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
