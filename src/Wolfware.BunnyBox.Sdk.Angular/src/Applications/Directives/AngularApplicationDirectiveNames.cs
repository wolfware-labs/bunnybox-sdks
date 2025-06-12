namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Directives;

/// <summary>
/// Represents a collection of constant names for Angular application-specific directives.
/// </summary>
/// <remarks>
/// These directive names are utilized to denote specific pieces of configuration
/// or metadata required by Angular applications, allowing for the organization
/// of related application information such as routes and dependencies.
/// </remarks>
internal sealed class AngularApplicationDirectiveNames
{
  /// <summary>
  /// Specifies a constant string identifier for the "Routes" directive in Angular applications.
  /// </summary>
  /// <remarks>
  /// This directive is used to define the routing configuration of an Angular application, including
  /// details about logical paths, physical paths, and associated components.
  /// It serves as a key for accessing routing details in the project manifest.
  /// </remarks>
  public const string Routes = "Routes";

  /// <summary>
  /// Specifies a constant string identifier for the "Dependencies" directive in Angular applications.
  /// </summary>
  /// <remarks>
  /// This directive is used to indicate the collection of package dependencies required by an Angular application.
  /// Dependencies typically include third-party libraries or modules that the application relies on to function correctly.
  /// It serves as a key for accessing dependency-related details in the project manifest.
  /// </remarks>
  public const string Dependencies = "Dependencies";

  /// <summary>
  /// Specifies a constant string identifier for the "DevDependencies" directive in Angular applications.
  /// </summary>
  /// <remarks>
  /// This directive is used to define metadata related to development-only dependencies
  /// within the context of an Angular application. It represents libraries, tools, or
  /// configurations that are required for development or testing purposes but are not
  /// included in the production build.
  /// </remarks>
  public const string DevDependencies = "DevDependencies";
}
