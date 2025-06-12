namespace BunnyBox.Sdk.Angular.Applications.Templates.Project;

/// <summary>
/// Represents the context information required for materializing an application project.
/// </summary>
/// <remarks>
/// This class encapsulates details about the SDK version and project metadata that are used
/// during the project generation or scaffolding process. It serves as a context object passed
/// to templates or materializers.
/// </remarks>
/// <remarks>
/// The <c>ApplicationProjectTemplateContext</c> is typically used in scenarios where
/// application scaffolding or code generation is performed, incorporating project-specific information
/// into the resulting output.
/// </remarks>
internal sealed class ApplicationProjectTemplateContext
{
  /// <summary>
  /// Gets the SDK version to be used during the application project scaffolding process.
  /// </summary>
  /// <remarks>
  /// This property holds the version of the SDK that defines the context and compatibility
  /// requirements for the generated project.
  /// It is typically initialized using the current assembly's semantic version and passed
  /// as part of the <c>ApplicationProjectTemplateContext</c> during project materialization.
  /// </remarks>
  public required string SdkVersion { get; init; }

  /// <summary>
  /// Gets the details of the project to be scaffolded.
  /// </summary>
  /// <remarks>
  /// This property contains metadata about the application project such as its name, version,
  /// description, and author. It provides the necessary information required during the
  /// scaffolding or materialization process as part of the project template context.
  /// </remarks>
  public required ProjectDetails Project { get; init; }
}
