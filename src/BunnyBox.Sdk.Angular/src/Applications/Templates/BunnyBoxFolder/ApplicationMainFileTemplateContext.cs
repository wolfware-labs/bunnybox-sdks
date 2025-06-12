using BunnyBox.Sdk.Angular.Extensions;
using BunnyBox.Sdk.Angular.Utils;
using BunnyBox.Sdk.Projects.Exceptions;

namespace BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;

/// <summary>
/// Represents the context for the main file template associated with a BunnyBox Folder.
/// </summary>
/// <remarks>
/// This context is primarily used in conjunction with file materialization processes
/// to generate and manipulate the main entry point file for an Angular application
/// within the BunnyBox framework.
/// </remarks>
internal sealed class ApplicationMainFileTemplateContext
{
  public required RouteDetails[] Routes { get; init; }

  /// <summary>
  /// Creates an instance of <see cref="ApplicationMainFileTemplateContext"/> from the specified project
  /// by extracting relevant route details.
  /// </summary>
  /// <param name="project">The project from which to create the <see cref="ApplicationMainFileTemplateContext"/>.
  /// This project contains metadata and structural information needed for template generation.</param>
  /// <returns>A new instance of <see cref="ApplicationMainFileTemplateContext"/> populated with route details
  /// derived from the specified project.</returns>
  public static ApplicationMainFileTemplateContext FromProject(Projects.Project project)
  {
    var routes = ApplicationMainFileTemplateContext.GetRoutes(project);
    return new ApplicationMainFileTemplateContext {Routes = routes,};
  }

  /// <summary>
  /// Retrieves the routes associated with the specified project by checking its manifest
  /// or generating routes dynamically if none are explicitly defined.
  /// </summary>
  /// <param name="project">The project from which to retrieve or generate route details. This includes
  /// the project's path and manifest information.</param>
  /// <returns>An array of <see cref="RouteDetails"/> representing the routes configured or generated
  /// for the specified project.</returns>
  /// <exception cref="InvalidProjectException">Thrown when no routes are found in the project
  /// and dynamic route generation results in an empty set.</exception>
  private static RouteDetails[] GetRoutes(Projects.Project project)
  {
    var configuredRoutes = project.Manifest.GetRoutes();
    if (configuredRoutes is not null)
    {
      return configuredRoutes;
    }

    var dynamicRoutes = DynamicRoutesGenerator.GenerateRoutes(project);
    if (dynamicRoutes.Length == 0)
    {
      throw new InvalidProjectException("No routes found in the project.");
    }

    return dynamicRoutes;
  }
}
