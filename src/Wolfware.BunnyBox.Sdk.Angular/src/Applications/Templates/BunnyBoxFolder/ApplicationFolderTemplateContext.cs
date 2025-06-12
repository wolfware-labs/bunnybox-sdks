using Wolfware.BunnyBox.Sdk.Angular.Extensions;
using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Directives;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;

/// <summary>
/// Represents the context for generating application folder templates within the BunnyBox Angular SDK.
/// </summary>
/// <remarks>
/// This class encapsulates metadata and configurations required to materialize application
/// folder templates. It transforms project data into the necessary format for template generation.
/// </remarks>
internal sealed class ApplicationFolderTemplateContext
{
  /// Represents the details associated with an application within the template context.
  /// This property contains metadata defining the application's configuration,
  /// such as its name, version, description, author, license, prefixes, styles,
  /// dependencies, and devDependencies.
  /// The `Application` property is part of the template context generated for a project
  /// during operations such as materializing a folder structure, initializing dependencies,
  /// or running build operations.
  /// It is initialized through the `ApplicationFolderTemplateContext.FromProject` method,
  /// which extracts information from the project's manifest and configuration.
  public required ApplicationDetails Application { get; init; }

  /// <summary>
  /// Creates a new instance of <see cref="ApplicationFolderTemplateContext"/> based on the given project.
  /// </summary>
  /// <param name="project">
  /// The project from which to derive the application folder template context.
  /// This object contains the project manifest and associated metadata required to populate the context.
  /// </param>
  /// <returns>
  /// An instance of <see cref="ApplicationFolderTemplateContext"/> populated with the details
  /// and dependencies from the provided project.
  /// </returns>
  public static ApplicationFolderTemplateContext FromProject(global::Wolfware.BunnyBox.Sdk.Projects.Project project)
  {
    var metadataDirective = project.Manifest.GetMetadata<AngularMetadataDirective>();
    var dependencies = project.Manifest.GetDependencies();
    var devDependencies = project.Manifest.GetDevDependencies();
    return new ApplicationFolderTemplateContext
    {
      Application = new ApplicationDetails
      {
        Name = metadataDirective.Name,
        Version = metadataDirective.Version,
        Description = metadataDirective.Description,
        Author = metadataDirective.Author,
        License = metadataDirective.License,
        Prefix = metadataDirective.Prefix,
        Style = metadataDirective.Style,
        GlobalStylesPath = "src/styles.scss",
        Dependencies = dependencies,
        DevDependencies = devDependencies,
      },
    };
  }
}
