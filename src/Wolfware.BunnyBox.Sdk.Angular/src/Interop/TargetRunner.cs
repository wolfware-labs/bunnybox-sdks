using System.Reflection;
using Wolfware.BunnyBox.Sdk.NodeJs.Abstractions;
using Wolfware.BunnyBox.Sdk.NodeJs.Models;
using Wolfware.BunnyBox.Sdk.Angular.Interop.Abstractions;

namespace Wolfware.BunnyBox.Sdk.Angular.Interop;

/// <summary>
/// Represents a runner responsible for executing Angular target operations
/// via scripts within the BunnyBox SDK.
/// </summary>
/// <remarks>
/// This class provides mechanisms to execute scripts leveraging the
/// <see cref="IModuleRunner"/> implementation, ensuring script operations are
/// performed in the appropriate runtime environment. It handles the loading
/// and execution of an embedded script resource named "run-target.js".
/// </remarks>
/// <threadsafety>
/// Instances of <see cref="TargetRunner"/> are thread-safe if the injected
/// <see cref="IModuleRunner"/> instance is also thread-safe.
/// </threadsafety>
internal sealed class TargetRunner : ITargetRunner
{
  private const string ScriptName = "run-target.js";
  private readonly IModuleRunner _moduleRunner;
  private readonly string _scriptContent;

  /// <summary>
  /// Represents a runner responsible for executing angular target operations via scripts
  /// within the BunnyBox SDK.
  /// </summary>
  /// <remarks>
  /// This class utilizes the configured <see cref="IModuleRunner"/> instance to run
  /// target-specific scripts, ensuring operations are executed within the appropriate
  /// runtime environment. It loads and executes a bundled script resource, specifically
  /// "run-target.js", which is embedded in the assembly.
  /// </remarks>
  /// <threadsafety>
  /// Instances of this class are thread-safe if the provided <see cref="IModuleRunner"/> implementation
  /// is thread-safe.
  /// </threadsafety>
  public TargetRunner(IModuleRunner moduleRunner)
  {
    this._moduleRunner = moduleRunner;
    var assembly = Assembly.GetExecutingAssembly();
    var scriptContentStream =
      assembly.GetManifestResourceStream($"Wolfware.BunnyBox.Sdk.Angular.src.Interop.Scripts.{TargetRunner.ScriptName}");
    if (scriptContentStream == null)
      throw new Exception("Resource not found");
    using var reader = new StreamReader(scriptContentStream);
    this._scriptContent = reader.ReadToEnd();
  }

  /// <summary>
  /// Executes a specified Angular target operation within a given execution context
  /// using a pre-defined script and runtime configuration.
  /// </summary>
  /// <param name="executionFolderPath">The file path to the folder where the target operation will be executed.</param>
  /// <param name="spec">The specifications of the target operation to be executed.</param>
  /// <param name="options">The configuration options governing the execution of the target operation.</param>
  /// <param name="cancellationToken">A token that can be used to propagate notification that the operation should be canceled.</param>
  /// <returns>A task that represents the asynchronous operation for running the target script.</returns>
  public async Task Run(
    string executionFolderPath,
    TargetSpec spec,
    TargetOptions options,
    CancellationToken cancellationToken = default
  )
  {
    var module = new NodeJsModule
    {
      Name = TargetRunner.ScriptName,
      Content = this._scriptContent,
      Arguments = [spec, options],
      WorkingDirectory = executionFolderPath
    };
    await this._moduleRunner.RunModule(module, cancellationToken);
  }
}
