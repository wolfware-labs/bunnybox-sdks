namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.Project;

/// <summary>
/// Represents detailed information about a project, including its name, version, description, and author.
/// </summary>
internal sealed class ProjectDetails
{
  /// <summary>
  /// Gets the name of the project.
  /// </summary>
  /// <remarks>
  /// This property specifies the name assigned to the project.
  /// It is required and provides a unique identifier or title for the project.
  /// </remarks>
  public required string Name { get; init; }

  /// <summary>
  /// Gets the version of the project.
  /// </summary>
  /// <remarks>
  /// This property specifies the version assigned to the project.
  /// It plays a key role in identifying the specific iteration or release.
  /// The value is required and typically follows semantic versioning conventions.
  /// </remarks>
  public required string Version { get; init; }

  /// <summary>
  /// Gets the description of the project.
  /// </summary>
  /// <remarks>
  /// This property provides detailed information about the purpose, scope, or functionality of the project.
  /// It is required and helps clarify the context and objectives of the project.
  /// </remarks>
  public required string Description { get; init; }

  /// <summary>
  /// Gets the author of the project.
  /// </summary>
  /// <remarks>
  /// This property specifies the individual or organization that created or is responsible for the project.
  /// It provides an attribution or ownership reference for the project.
  /// </remarks>
  public required string Author { get; init; }
}
