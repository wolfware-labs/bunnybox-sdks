using Wolfware.BunnyBox.Sdk.Angular.Extensions;
using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.NodeJs.Abstractions;
using Wolfware.BunnyBox.Sdk.NodeJs.Extensions;
using Wolfware.BunnyBox.Sdk.Projects;
using Wolfware.BunnyBox.Sdk.Templates.Abstractions;
using MediatR;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;
using Wolfware.BunnyBox.Sdk.Angular.Interop;
using Wolfware.BunnyBox.Sdk.Angular.Interop.Abstractions;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Commands;

/// <summary>
/// A command record that initiates a build operation for an Angular application with the specified build details.
/// Implements IRequest to be handled by MediatR for command processing. Returns a BuildResponse as the result.
/// </summary>
/// <param name="Details">The build request containing project information and build configuration options.</param>
internal sealed record BuildApplication(BuildRequest Details) : IRequest<BuildResponse>;

/// <summary>
/// A command record that initiates a build operation for the given project with the specified details.
/// Implements IRequest to be handled by MediatR for command processing. Returns a BuildResponse as the result.
/// </summary>
internal sealed class BuildApplicationHandler : IRequestHandler<BuildApplication, BuildResponse>
{
  private readonly ITargetRunner _targetRunner;
  private readonly ITemplateMaterializer _templateMaterializer;
  private readonly INpmRunner _npmRunner;

  public BuildApplicationHandler(
    ITargetRunner targetRunner,
    ITemplateMaterializer templateMaterializer,
    INpmRunner npmRunner
  )
  {
    _targetRunner = targetRunner;
    _templateMaterializer = templateMaterializer;
    _npmRunner = npmRunner;
  }

  public async Task<BuildResponse> Handle(BuildApplication request, CancellationToken cancellationToken)
  {
    try
    {
      var templateContext = await this.SyncBunnyBoxFolder(request.Details.Project, cancellationToken)
        .ConfigureAwait(false);
      await this.SyncRoutesFile(request.Details.Project, cancellationToken).ConfigureAwait(false);
      request.Details.Project.PopulateSourceFolder(true);
      await this._npmRunner.InitializeProjectDependencies(request.Details.Project).ConfigureAwait(false);
      var spec = new TargetSpec
      {
        Project = templateContext.Application.Name, Target = "build", Configuration = "production"
      };
      var options = new TargetOptions
      {
        OutputPath = request.Details.OutputPath,
        BaseHref = "/",
        DeployUrl = "/",
        Watch = false,
        SourceMap = false,
        Aot = true,
        Optimization = true,
        Verbose = request.Details.Verbose,
      };
      await this._targetRunner.Run(request.Details.Project.BunnyBoxFolder.Path, spec, options, cancellationToken)
        .ConfigureAwait(false);

      return Response.Ok<BuildResponse>(request.Details.Project.Path);
    }
    catch (Exception e)
    {
      return Response.Fail<BuildResponse>(request.Details.Project.Path, e.GetFullMessage());
    }
  }

  private async Task<ApplicationFolderTemplateContext> SyncBunnyBoxFolder(Project project,
    CancellationToken cancellationToken)
  {
    var templateContext = ApplicationFolderTemplateContext.FromProject(project);
    await this._templateMaterializer.MaterializeBunnyBoxFolder(
      templateContext,
      project.BunnyBoxFolder.Path,
      cancellationToken: cancellationToken
    ).ConfigureAwait(false);
    return templateContext;
  }

  private async Task SyncRoutesFile(Project project, CancellationToken cancellationToken)
  {
    var templateContext = ApplicationMainFileTemplateContext.FromProject(project);
    await this._templateMaterializer.MaterializeMainFile(
      templateContext,
      project.BunnyBoxFolder.Path,
      cancellationToken: cancellationToken
    ).ConfigureAwait(false);
  }
}
