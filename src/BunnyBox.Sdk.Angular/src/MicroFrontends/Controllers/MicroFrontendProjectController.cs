using BunnyBox.Sdk.Angular.MicroFrontends.Commands;
using BunnyBox.Sdk.Projects;
using BunnyBox.Sdk.Projects.Abstractions;
using MediatR;

namespace BunnyBox.Sdk.Angular.MicroFrontends.Controllers;

/// <summary>
/// Represents the controller responsible for handling operations related to a micro-frontend project.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IProjectController"/> interface and provides methods for
/// building and running a micro-frontend project.
/// </remarks>
internal class MicroFrontendProjectController : IProjectController
{
  private readonly IMediator _mediator;

  /// <summary>
  /// Initializes a new instance of the <see cref="MicroFrontendProjectController"/> class.
  /// </summary>
  /// <param name="mediator">An instance of <see cref="IMediator"/> used for sending commands and queries in the application.</param>
  public MicroFrontendProjectController(IMediator mediator)
  {
    _mediator = mediator;
  }

  /// <inheritdoc />
  public Task<ScaffoldResponse> Scaffold(ScaffoldRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new ScaffoldMicroFrontend(request), cancellationToken);
  }

  /// <inheritdoc />
  public Task<BuildResponse> Build(BuildRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new BuildMicroFrontend(request), cancellationToken);
  }

  /// <inheritdoc />
  public Task<RunResponse> Run(RunRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new RunMicroFrontend(request), cancellationToken);
  }

  /// <inheritdoc />
  public Task<DivorceResponse> Divorce(DivorceRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new DivorceMicroFrontend(request), cancellationToken);
  }

  /// <inheritdoc />
  public Task<ResetResponse> Reset(ResetRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new ResetMicroFrontend(request), cancellationToken);
  }
}
