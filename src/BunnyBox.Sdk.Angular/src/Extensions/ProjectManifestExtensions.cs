/***********************************************
Author: Mariano Santoro
Description: The ProjectExtensions
Created On: 05/11/2025
Modified By:
Modified On:
Modified Comments:
Ticket Number:
************************************************/

using BunnyBox.Sdk.Angular.Applications.Definitions;
using BunnyBox.Sdk.Angular.Applications.Directives;
using BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;
using BunnyBox.Sdk.Angular.MicroFrontends.Definitions;
using BunnyBox.Sdk.Extensions;
using BunnyBox.Sdk.Projects;

namespace BunnyBox.Sdk.Angular.Extensions;

/// <summary>
/// Provides extension methods for interacting with a <see cref="ProjectManifest"/> object
/// to extract and manipulate Angular-specific project directives.
/// </summary>
internal static class ProjectManifestExtensions
{
  /// <summary>
  /// Retrieves the route details from the given <see cref="ProjectManifest"/> instance
  /// based on Angular application-specific directives.
  /// </summary>
  /// <param name="project">The <see cref="ProjectManifest"/> instance to extract route details from.</param>
  /// <returns>An array of <see cref="RouteDetails"/> containing the logical path, physical path, and component for each route, or null if no routes are defined.</returns>
  public static RouteDetails[]? GetRoutes(this ProjectManifest project)
  {
    return project.GetDirective<RouteDetails[]>(AngularApplicationDirectiveNames.Routes);
  }

  /// <summary>
  /// Retrieves the dependency details from the specified <see cref="ProjectManifest"/> instance
  /// based on Angular application-specific directives.
  /// </summary>
  /// <param name="project">The <see cref="ProjectManifest"/> instance to extract dependency details from.</param>
  /// <returns>An array of <see cref="DependencyDetails"/> containing the name and version of each dependency, or an empty array if no dependencies are defined.</returns>
  public static DependencyDetails[] GetDependencies(this ProjectManifest project)
  {
    return project.GetDirective<DependencyDetails[]>(AngularApplicationDirectiveNames.Dependencies) ?? [];
  }

  /// <summary>
  /// Retrieves the development dependencies for the specified <see cref="ProjectManifest"/> instance
  /// based on the associated Angular application directive.
  /// </summary>
  /// <param name="project">The <see cref="ProjectManifest"/> instance from which to extract the development dependencies.</param>
  /// <returns>An array of <see cref="DependencyDetails"/> specifying the name and version of each development dependency, or an empty array if no development dependencies are defined.</returns>
  public static DependencyDetails[] GetDevDependencies(this ProjectManifest project)
  {
    return project.GetDirective<DependencyDetails[]>(AngularApplicationDirectiveNames.DevDependencies) ?? [];
  }

  /// <summary>
  /// Determines whether a given <see cref="ProjectManifest"/> instance represents an Angular application.
  /// </summary>
  /// <param name="project">The <see cref="ProjectManifest"/> instance to be checked.</param>
  /// <returns>A boolean value indicating whether the manifest corresponds to an Angular application.</returns>
  public static bool IsApplication(this ProjectManifest project)
  {
    return project.Is(ApplicationResourceDefinition.ResourceName);
  }

  /// <summary>
  /// Determines whether the given <see cref="ProjectManifest"/> instance represents a Micro Frontend project
  /// based on the project type defined in its header.
  /// </summary>
  /// <param name="project">The <see cref="ProjectManifest"/> instance to evaluate.</param>
  /// <returns>
  /// True if the project is identified as a Micro Frontend; otherwise, false.
  /// </returns>
  public static bool IsMicroFrontend(this ProjectManifest project)
  {
    return project.Is(MicroFrontendResourceDefinition.ResourceName);
  }
}
