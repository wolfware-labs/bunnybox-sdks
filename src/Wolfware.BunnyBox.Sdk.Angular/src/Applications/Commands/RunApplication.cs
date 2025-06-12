using Wolfware.BunnyBox.Sdk.Angular.Extensions;
using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.NodeJs.Abstractions;
using Wolfware.BunnyBox.Sdk.NodeJs.Extensions;
using Wolfware.BunnyBox.Sdk.Projects;
using Wolfware.BunnyBox.Sdk.Templates.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;
using Wolfware.BunnyBox.Sdk.Angular.Interop;
using Wolfware.BunnyBox.Sdk.Angular.Interop.Abstractions;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Commands;

/// <summary>
/// Represents a command to run an Angular application through the BunnyBox SDK.
/// This command initializes and serves the application with development configuration.
/// </summary>
/// <param name="Details">The run request containing the project information and configuration needed to execute the application.</param>
internal sealed record RunApplication(RunRequest Details) : IRequest<RunResponse>;

    /// <param name="templateMaterializer">The template materializer service used to generate files and folders from templates based on the application context.</param>
internal sealed class RunApplicationHandler : IRequestHandler<RunApplication, RunResponse>
{
  private readonly ITemplateMaterializer _templateMaterializer;
  private readonly ITargetRunner _targetRunner;
  private readonly INpmRunner _npmRunner;
  private readonly ILogger<RunApplicationHandler> _logger;

  public RunApplicationHandler(
    ITemplateMaterializer templateMaterializer,
    ITargetRunner targetRunner,
    INpmRunner npmRunner,
    ILogger<RunApplicationHandler> logger
  )
  {
    _templateMaterializer = templateMaterializer;
    _targetRunner = targetRunner;
    _npmRunner = npmRunner;
    _logger = logger;
  }

  public async Task<RunResponse> Handle(RunApplication request, CancellationToken cancellationToken)
  {
    void OnProjectContentChanged(FileSystemEventArgs e) =>
      this.SyncChangedContent(request.Details.Project, e, cancellationToken).GetAwaiter().GetResult();

    try
    {
      await this.SyncBunnyBoxFolder(request.Details.Project, cancellationToken).ConfigureAwait(false);
      await this.SyncRoutesFile(request.Details.Project, cancellationToken).ConfigureAwait(false);
      await this._npmRunner.InitializeProjectDependencies(request.Details.Project).ConfigureAwait(false);
      request.Details.Project.PopulateSourceFolder(true);

      request.Details.Project.ContentWatcher.Changed += OnProjectContentChanged;

      var projectMetadata = request.Details.Project.Manifest.GetMetadata();
      var spec = new TargetSpec {Project = projectMetadata.Name, Target = "serve", Configuration = "development"};
      var options = new TargetOptions();
      await this._targetRunner.Run(
        request.Details.Project.BunnyBoxFolder.Path,
        spec,
        options,
        cancellationToken
      ).ConfigureAwait(false);

      return Response.Ok<RunResponse>(request.Details.Project.Path);
    }
    catch (Exception e)
    {
      return Response.Fail<RunResponse>(request.Details.Project.Path, e.Message);
    }
    finally
    {
      request.Details.Project.ContentWatcher.Changed -= OnProjectContentChanged;
    }
  }

  private async Task SyncChangedContent(Project project, FileSystemEventArgs eventArgs,
    CancellationToken cancellationToken)
  {
    try
    {
      _logger.LogDebug(
        "Updating project content [{ChangeType}]: {ContentPath}",
        eventArgs.FullPath,
        eventArgs.ChangeType
      );

      if (eventArgs.ChangeType.HasFlag(WatcherChangeTypes.Deleted))
      {
        project.DeleteFromSourceFolder(eventArgs.FullPath);
        return;
      }

      project.CopyToSourceFolder(eventArgs.FullPath);

      if (project.IsPage(eventArgs.FullPath))
      {
        await this.SyncRoutesFile(project, cancellationToken);
      }
    }
    catch (Exception exception)
    {
      this._logger.LogError(
        exception,
        "An error occurred while handling project content change: {FilePath}",
        eventArgs.FullPath
      );
    }
  }

  private async Task SyncBunnyBoxFolder(Project project, CancellationToken cancellationToken)
  {
    var templateContext = ApplicationFolderTemplateContext.FromProject(project);
    await this._templateMaterializer.MaterializeBunnyBoxFolder(
      templateContext,
      project.BunnyBoxFolder.Path,
      cancellationToken: cancellationToken
    ).ConfigureAwait(false);
  }

  private Task SyncRoutesFile(Project project, CancellationToken cancellationToken)
  {
    var templateContext = ApplicationMainFileTemplateContext.FromProject(project);
    return this._templateMaterializer.MaterializeMainFile(
      templateContext,
      project.BunnyBoxFolder.Path,
      cancellationToken: cancellationToken
    );
  }
}
