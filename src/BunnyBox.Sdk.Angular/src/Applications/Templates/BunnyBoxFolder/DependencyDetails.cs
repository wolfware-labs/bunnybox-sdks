namespace BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;

/// <summary>
/// Represents the details of a dependency, including its name and version.
/// </summary>
internal sealed class DependencyDetails
{
  /// <summary>
  /// Gets the name of the dependency being represented.
  /// </summary>
  public required string Name { get; init; }

  /// <summary>
  /// Gets the version of the dependency being represented.
  /// </summary>
  public required string Version { get; init; }
}
