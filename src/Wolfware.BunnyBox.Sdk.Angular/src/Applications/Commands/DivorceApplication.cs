using Wolfware.BunnyBox.Sdk.Projects;
using MediatR;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Commands;

/// <summary>
/// Represents a command to process a divorce operation for a project within the BunnyBox Angular SDK.
/// This command handles the separation of a project from the BunnyBox system.
/// </summary>
/// <param name="Details">The divorce request containing the project information and parameters needed for the divorce operation.</param>
internal sealed record DivorceApplication(DivorceRequest Details) : IRequest<DivorceResponse>;

/// <summary>
/// Represents a handler for processing divorce operations within the BunnyBox Angular SDK.
/// This handler implements the logic for executing project divorces and returning appropriate responses.
/// </summary>
internal sealed class DivorceApplicationHandler : IRequestHandler<DivorceApplication, DivorceResponse>
{
  public Task<DivorceResponse> Handle(DivorceApplication request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
