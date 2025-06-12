using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.Templates.Abstractions;
using Wolfware.BunnyBox.Sdk.Templates.Configuration;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.Project;

namespace Wolfware.BunnyBox.Sdk.Angular.Extensions;

/// <summary>
/// Provides extension methods for materializing templates into project or folder structures
/// using <see cref="ITemplateMaterializer" />.
/// </summary>
internal static class TemplateMaterializerExtensions
{
  /// <summary>
  /// Materializes a project by embedding the specified folder's contents based on the provided template context and materialization options.
  /// </summary>
  /// <param name="templateMaterializer">The instance of <see cref="ITemplateMaterializer"/> responsible for materializing the project.</param>
  /// <param name="context">The project template context containing details required for materialization.</param>
  /// <param name="folderPath">The path to the folder whose contents will be embedded during materialization.</param>
  /// <param name="materializationOptions">
  /// Optional materialization options to customize the process. If not provided, defaults to overwriting existing files.
  /// </param>
  /// <param name="cancellationToken">
  /// A cancellation token to observe while waiting for the asynchronous materialization operation to complete.
  /// </param>
  /// <returns>A Task that represents the asynchronous materialization operation.</returns>
  public static async Task MaterializeProject(
    this ITemplateMaterializer templateMaterializer,
    ApplicationProjectTemplateContext context,
    string folderPath,
    MaterializationOptions? materializationOptions = null,
    CancellationToken cancellationToken = default
  )
  {
    materializationOptions ??= new MaterializationOptions {OverwriteExistingFiles = true};
    await templateMaterializer.MaterializeEmbeddedFolder(
      context,
      folderPath,
      materializationOptions,
      cancellationToken: cancellationToken
    );
  }

  /// <summary>
  /// Materializes the BunnyBox folder by embedding the specified folder's contents
  /// based on the provided application folder template context and materialization options.
  /// </summary>
  /// <param name="templateMaterializer">
  /// The instance of <see cref="ITemplateMaterializer"/> responsible for performing the materialization process.
  /// </param>
  /// <param name="context">
  /// The application folder template context containing details required for materialization.
  /// </param>
  /// <param name="folderPath">
  /// The path to the folder whose contents will be embedded during materialization.
  /// </param>
  /// <param name="materializationOptions">
  /// Optional materialization options to customize the materialization process.
  /// If not provided, defaults to overwriting existing files.
  /// </param>
  /// <param name="cancellationToken">
  /// A cancellation token to observe while waiting for the asynchronous materialization operation to complete.
  /// </param>
  /// <returns>A Task that represents the asynchronous operation of materializing the folder.</returns>
  public static async Task MaterializeBunnyBoxFolder(
    this ITemplateMaterializer templateMaterializer,
    ApplicationFolderTemplateContext context,
    string folderPath,
    MaterializationOptions? materializationOptions = null,
    CancellationToken cancellationToken = default
  )
  {
    materializationOptions ??= new MaterializationOptions {OverwriteExistingFiles = true};
    await templateMaterializer.MaterializeEmbeddedFolder(
      context,
      folderPath,
      materializationOptions,
      cancellationToken: cancellationToken
    );
  }

  /// <summary>
  /// Materializes the main file by embedding the specified folder's contents based on the provided template context and materialization options.
  /// </summary>
  /// <param name="templateMaterializer">The instance of <see cref="ITemplateMaterializer"/> responsible for materializing the main file.</param>
  /// <param name="context">The template context containing details required for the main file materialization.</param>
  /// <param name="folderPath">The path to the folder whose contents will be embedded during the main file materialization process.</param>
  /// <param name="materializationOptions">
  /// Optional materialization options to customize the process. If not provided, defaults to overwriting existing files.
  /// </param>
  /// <param name="cancellationToken">
  /// A cancellation token to observe while waiting for the asynchronous main file materialization operation to complete.
  /// </param>
  /// <returns>A Task that represents the asynchronous main file materialization operation.</returns>
  public static async Task MaterializeMainFile(
    this ITemplateMaterializer templateMaterializer,
    ApplicationMainFileTemplateContext context,
    string folderPath,
    MaterializationOptions? materializationOptions = null,
    CancellationToken cancellationToken = default
  )
  {
    materializationOptions ??= new MaterializationOptions {OverwriteExistingFiles = true};
    await templateMaterializer.MaterializeEmbeddedFolder(
      context,
      folderPath,
      materializationOptions,
      cancellationToken: cancellationToken
    );
  }
}
