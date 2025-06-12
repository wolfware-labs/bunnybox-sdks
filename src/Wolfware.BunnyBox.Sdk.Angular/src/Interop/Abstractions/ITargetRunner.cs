namespace Wolfware.BunnyBox.Sdk.Angular.Interop.Abstractions;

/// <summary>
/// Defines an interface for executing tasks on an Angular project with specified parameters.
/// </summary>
internal interface ITargetRunner
{
  /// Executes a target operation within a specific execution folder based on the provided specifications and options.
  /// <param name="executionFolderPath">
  /// The absolute path to the folder where the target operation should be executed.
  /// </param>
  /// <param name="spec">
  /// The specifications of the target operation to execute.
  /// </param>
  /// <param name="options">
  /// The options used to configure the execution of the target operation.
  /// </param>
  /// <param name="cancellationToken">
  /// The optional token used to observe cancellation requests.
  /// </param>
  /// <return>
  /// A task that represents the asynchronous operation, returning the result of the operation as a string.
  /// </return>
  Task Run(
    string executionFolderPath,
    TargetSpec spec,
    TargetOptions options,
    CancellationToken cancellationToken = default
  );
}
