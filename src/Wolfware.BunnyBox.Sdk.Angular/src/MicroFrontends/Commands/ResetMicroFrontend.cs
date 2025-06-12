using Wolfware.BunnyBox.Sdk.Projects;
using MediatR;

namespace Wolfware.BunnyBox.Sdk.Angular.MicroFrontends.Commands;

internal sealed record ResetMicroFrontend(ResetRequest Details) : IRequest<ResetResponse>;

internal sealed class ResetMicroFrontendHandler : IRequestHandler<ResetMicroFrontend, ResetResponse>
{
  public Task<ResetResponse> Handle(ResetMicroFrontend request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
