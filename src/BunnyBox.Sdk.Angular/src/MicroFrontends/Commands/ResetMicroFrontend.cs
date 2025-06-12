using BunnyBox.Sdk.Projects;
using MediatR;

namespace BunnyBox.Sdk.Angular.MicroFrontends.Commands;

internal sealed record ResetMicroFrontend(ResetRequest Details) : IRequest<ResetResponse>;

internal sealed class ResetMicroFrontendHandler : IRequestHandler<ResetMicroFrontend, ResetResponse>
{
  public Task<ResetResponse> Handle(ResetMicroFrontend request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
