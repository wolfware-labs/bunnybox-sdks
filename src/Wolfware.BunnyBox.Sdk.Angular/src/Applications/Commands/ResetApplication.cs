using Wolfware.BunnyBox.Sdk.Projects;
using MediatR;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Commands;

/// <summary>
/// Represents a command to reset an application to its initial state, implementing the MediatR IRequest pattern.
/// This command is used to clean and rebuild the project environment.
/// </summary>
/// <param name="Details">Contains the configuration and parameters needed for the reset operation</param>
internal sealed record ResetApplication(ResetRequest Details) : IRequest<ResetResponse>;

/// <summary>
/// Handles the processing of application reset commands, implementing the MediatR request handler pattern.
/// This handler is responsible for executing the reset operation defined in the ResetApplication command.
/// </summary>
internal sealed class ResetApplicationHandler : IRequestHandler<ResetApplication, ResetResponse>
{
  public Task<ResetResponse> Handle(ResetApplication request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
