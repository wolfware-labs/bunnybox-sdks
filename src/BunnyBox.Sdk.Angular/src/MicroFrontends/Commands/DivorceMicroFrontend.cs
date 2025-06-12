using BunnyBox.Sdk.Projects;
using MediatR;

namespace BunnyBox.Sdk.Angular.MicroFrontends.Commands;

internal sealed record DivorceMicroFrontend(DivorceRequest Details) : IRequest<DivorceResponse>;

internal sealed class DivorceMicroFrontendHandler : IRequestHandler<DivorceMicroFrontend, DivorceResponse>
{
  public Task<DivorceResponse> Handle(DivorceMicroFrontend request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
