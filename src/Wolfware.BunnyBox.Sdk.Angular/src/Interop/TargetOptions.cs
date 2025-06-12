namespace Wolfware.BunnyBox.Sdk.Angular.Interop;

/// <summary>
/// Represents configuration options for executing an Angular target within the BunnyBox SDK.
/// </summary>
/// <remarks>
/// This class encapsulates various settings that can be used to override or customize
/// the behavior of Angular build/serve actions. Properties such as paths, optimizations,
/// and source map configurations can be specified here.
/// </remarks>
internal sealed class TargetOptions
{
  /// <summary>
  /// Gets or sets the output path where the build artifacts will be written.
  /// </summary>
  /// <remarks>
  /// This property specifies the directory to which the generated files, such as compiled JavaScript,
  /// CSS, and other assets, will be emitted during the build process.
  /// </remarks>
  public string? OutputPath { get; set; }

  /// <summary>
  /// Gets or sets the base href for the application.
  /// </summary>
  /// <remarks>
  /// This property specifies the base URL of the application, which is used to resolve all relative paths.
  /// It is commonly used when deploying an application under a specific directory or sub-path within a domain.
  /// </remarks>
  public string? BaseHref { get; set; }

  /// <summary>
  /// Gets or sets the URL that will be used to deploy static assets for the Angular application.
  /// </summary>
  /// <remarks>
  /// This property specifies a base path for resolving and serving any static files deployed with the application.
  /// It can be used to configure the location where resources such as images, scripts, and stylesheets will be loaded
  /// when the application is accessed in the browser.
  /// </remarks>
  public string? DeployUrl { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether the build or serve process should watch files for changes.
  /// </summary>
  /// <remarks>
  /// When set to true, the process will monitor the file system for changes and automatically rebuild
  /// or reload as needed, providing a continuous development experience. This is typically used in
  /// scenarios such as development servers or iterative testing.
  /// </remarks>
  public bool? Watch { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether source maps should be generated during the build process.
  /// </summary>
  /// <remarks>
  /// Source maps provide a way to map the compiled code back to the original source files, which can aid
  /// in debugging by allowing developers to view and debug the original code instead of the compiled output.
  /// Enabling this property may increase build time and output size.
  /// </remarks>
  public bool? SourceMap { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether ahead-of-time (AOT) compilation is enabled.
  /// </summary>
  /// <remarks>
  /// AOT compilation improves application performance by pre-compiling Angular templates
  /// and components during the build process. This setting can help detect template errors
  /// earlier and produce smaller bundles for deployment.
  /// </remarks>
  public bool? Aot { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether optimization is enabled for the build process.
  /// </summary>
  /// <remarks>
  /// When set to true, this property enables optimizations such as minification, tree-shaking,
  /// and other performance improvements, resulting in a smaller and more efficient output.
  /// If disabled, the build may include additional debugging information and unoptimized code.
  /// </remarks>
  public bool? Optimization { get; set; }

  /// <summary>
  /// Gets or sets a value indicating whether detailed logging information should be displayed during the operation.
  /// </summary>
  /// <remarks>
  /// This property controls the verbosity of the output, typically providing more detailed
  /// diagnostic information for debugging or monitoring purposes when set to true.
  /// </remarks>
  public bool? Verbose { get; set; }
}
