using Wolfware.BunnyBox.Sdk.Projects;
using Wolfware.BunnyBox.Sdk.Projects.Abstractions;
using MediatR;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Commands;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Controllers;

/// <summary>
/// Represents a controller responsible for managing operations such as scaffolding,
/// building, running, divorcing, and resetting for an application project.
/// </summary>
/// <remarks>
/// This controller implements <see cref="IProjectController"/> and acts as an intermediary
/// to handle these operations using the MediatR pipeline.
/// </remarks>
internal sealed class ApplicationProjectController : IProjectController
{
  private readonly IMediator _mediator;

  /// <summary>
  /// Initializes a new instance of the ApplicationProjectController class.
  /// </summary>
  /// <param name="mediator">The mediator instance used to handle command requests through the MediatR pipeline.</param>
  public ApplicationProjectController(IMediator mediator)
  {
    _mediator = mediator;
  }

  /// <inheritdoc />
  public Task<ScaffoldResponse> Scaffold(ScaffoldRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new ScaffoldApplication(request), cancellationToken);
  }

  /// <inheritdoc />
  public Task<BuildResponse> Build(BuildRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new BuildApplication(request), cancellationToken);
  }

  /// <inheritdoc />
  public Task<RunResponse> Run(RunRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new RunApplication(request), cancellationToken);
  }

  /// <inheritdoc />
  public Task<DivorceResponse> Divorce(DivorceRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new DivorceApplication(request), cancellationToken);
  }

  /// <inheritdoc />
  public Task<ResetResponse> Reset(ResetRequest request, CancellationToken cancellationToken = default)
  {
    return _mediator.Send(new ResetApplication(request), cancellationToken);
  }
}
