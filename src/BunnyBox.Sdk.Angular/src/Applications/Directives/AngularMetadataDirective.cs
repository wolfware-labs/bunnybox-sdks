using BunnyBox.Sdk.Projects.Directives;

namespace BunnyBox.Sdk.Angular.Applications.Directives;

/// <summary>
/// Represents an Angular-specific metadata directive within a project.
/// </summary>
/// <remarks>
/// This directive extends the base <see cref="ProjectMetadataDirective"/>
/// and adds Angular-specific properties to define configuration details for Angular applications.
/// </remarks>
internal sealed class AngularMetadataDirective : ProjectMetadataDirective
{
  /// <summary>
  /// Gets the prefix used for naming conventions within an Angular application.
  /// </summary>
  /// <remarks>
  /// The prefix is used in Angular applications for defining custom elements
  /// such as components, directives, or other entities requiring unique identifiers.
  /// Conventionally, this is a short string prefixed to names to ensure consistency
  /// and to avoid naming conflicts in a project's ecosystem.
  /// </remarks>
  public string Prefix { get; init; } = "app";

  /// <summary>
  /// Gets the default stylesheet format used in the Angular application.
  /// </summary>
  /// <remarks>
  /// This property determines the primary styling format or extension
  /// used within the project's components, such as "css", "scss", "less", etc.
  /// It influences the structure of component files and the styles configuration
  /// when generating or managing Angular components or projects.
  /// </remarks>
  public string Style { get; init; } = "scss";
}
