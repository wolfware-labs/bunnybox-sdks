namespace BunnyBox.Sdk.Angular.Interop;

/// <summary>
/// Represents the specifications for targeting an Angular project, defining key parameters
/// required to execute a specific action or build process for an Angular project.
/// </summary>
/// <remarks>
/// This class is intended to encapsulate the details of a project, its target, and its configuration.
/// These specifications are primarily used when executing operations such as builds or deployments
/// within an Angular project through a runner service.
/// </remarks>
internal sealed class TargetSpec
{
  /// <summary>
  /// Gets or sets the name of the Angular project being targeted.
  /// </summary>
  /// <remarks>
  /// The specified project name is used to determine the context on which operations
  /// are executed, such as building or deploying a specific Angular project.
  /// </remarks>
  public string Project { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the target for the Angular project being specified.
  /// </summary>
  /// <remarks>
  /// The target defines the specific task or operation to be executed on the Angular project,
  /// such as 'build', 'test', or 'serve', providing clarity for tools and runners about
  /// the intended operation.
  /// </remarks>
  public string Target { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the configuration being applied to the target action or build process.
  /// </summary>
  /// <remarks>
  /// The configuration determines specific settings and options used during an operation,
  /// such as "production," "development," or other custom configurations defined in the Angular workspace.
  /// </remarks>
  public string Configuration { get; set; } = string.Empty;
}
