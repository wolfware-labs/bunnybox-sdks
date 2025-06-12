using Wolfware.BunnyBox.Sdk.Angular.Extensions;
using Wolfware.BunnyBox.Sdk.Enums;
using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.Projects;
using Wolfware.BunnyBox.Sdk.Templates.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.Project;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Commands;

/// <summary>
/// Command to scaffold a new application using the provided scaffold request details.
/// </summary>
/// <param name="Details">The scaffolding request parameters including project path, name, version, description, author and force flag.</param>
internal sealed record ScaffoldApplication(ScaffoldRequest Details) : IRequest<ScaffoldResponse>;

/// <summary>
/// Handles the scaffold application command by creating a new project directory and materializing project templates.
/// Implements IRequestHandler to process ScaffoldApplication requests and return ScaffoldResponse results.
/// </summary>
internal sealed class ScaffoldApplicationHandler : IRequestHandler<ScaffoldApplication, ScaffoldResponse>
{
  private readonly ITemplateMaterializer _templateMaterializer;
  private readonly ILogger<ScaffoldApplicationHandler> _logger;

  public ScaffoldApplicationHandler(
    ITemplateMaterializer templateMaterializer,
    ILogger<ScaffoldApplicationHandler> logger
  )
  {
    _templateMaterializer = templateMaterializer;
    _logger = logger;
  }

  public async Task<ScaffoldResponse> Handle(ScaffoldApplication request, CancellationToken cancellationToken)
  {
    try
    {
      if (Directory.Exists(request.Details.ProjectPath) && !request.Details.Force)
      {
        return Response.Fail<ScaffoldResponse>(request.Details.ProjectPath,
          $"Directory already exists: {request.Details.ProjectPath}");
      }

      if (Directory.Exists(request.Details.ProjectPath))
      {
        _logger.LogWarning("Directory already exists, deleting: {ProjectPath}", request.Details.ProjectPath);
        Directory.Delete(request.Details.ProjectPath, true);
      }

      Directory.CreateDirectory(request.Details.ProjectPath);
      _logger.LogDebug("Directory created: {ProjectPath}", request.Details.ProjectPath);

      var templateContext = new ApplicationProjectTemplateContext
      {
        SdkVersion = this.GetType().Assembly.GetSemVer().ToString(SemVerPrecision.Prerelease),
        Project = new ProjectDetails
        {
          Name = request.Details.ProjectName,
          Version = request.Details.ProjectVersion,
          Description = request.Details.ProjectDescription,
          Author = request.Details.ProjectAuthor
        }
      };
      await this._templateMaterializer.MaterializeProject(
        templateContext,
        request.Details.ProjectPath,
        cancellationToken: cancellationToken
      ).ConfigureAwait(false);

      return Response.Ok<ScaffoldResponse>(request.Details.ProjectPath);
    }
    catch (Exception e)
    {
      return Response.Fail<ScaffoldResponse>(request.Details.ProjectPath, e.Message);
    }
  }
}
