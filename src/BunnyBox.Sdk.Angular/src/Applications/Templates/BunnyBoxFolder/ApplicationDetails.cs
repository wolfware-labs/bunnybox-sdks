namespace BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;

/// <summary>
/// Represents the details of an application, including its metadata, dependencies, and settings.
/// </summary>
internal sealed class ApplicationDetails
{
  /// <summary>
  /// Represents the name of the application.
  /// </summary>
  /// <remarks>
  /// This property is used as a key identifier for the application
  /// and may be utilized in various operations such as project initialization,
  /// build processes, or configuration contexts.
  /// </remarks>
  public required string Name { get; init; }

  /// <summary>
  /// Represents the version of the application.
  /// </summary>
  /// <remarks>
  /// This property is used to identify the specific version of the application.
  /// It is typically leveraged in version control, compatibility checks, or deployment processes.
  /// </remarks>
  public required string Version { get; init; }

  /// <summary>
  /// Represents the description of the application.
  /// </summary>
  /// <remarks>
  /// This property provides a summary or detailed overview of the application,
  /// outlining its purpose, functionality, or other significant details.
  /// It may be used in documentation, user interfaces, or metadata representations.
  /// </remarks>
  public required string Description { get; init; }

  /// <summary>
  /// Represents the author of the application.
  /// </summary>
  /// <remarks>
  /// This property is used to define the creator or maintainer of the application.
  /// It can serve as metadata for documentation, attribution, or licensing purposes.
  /// </remarks>
  public required string Author { get; init; }

  /// <summary>
  /// Represents the licensing information of the application.
  /// </summary>
  /// <remarks>
  /// This property defines the legal terms under which the application can be used, modified, or distributed.
  /// It is typically sourced from project metadata and may be referenced during initialization, compliance checks,
  /// or documentation generation processes.
  /// </remarks>
  public required string License { get; init; }

  /// <summary>
  /// Represents the prefix used for defining component and directive selectors within the application.
  /// </summary>
  /// <remarks>
  /// This property standardizes the naming convention for Angular selectors in the application
  /// to ensure consistent and unique identification of components and directives.
  /// </remarks>
  public required string Prefix { get; init; }

  /// <summary>
  /// Specifies the default style configuration for the application.
  /// </summary>
  /// <remarks>
  /// This property determines the primary styling approach, such as CSS, SCSS, or LESS,
  /// to be utilized throughout the application's structure and components. It is a key
  /// setting for styling alignment in the project.
  /// </remarks>
  public required string Style { get; init; }

  /// <summary>
  /// Specifies the path to the global styles file for the application.
  /// </summary>
  /// <remarks>
  /// This property defines the location of the main stylesheet file utilized globally across the application.
  /// It is typically an entry point for applying shared styles and overriding default theme settings.
  /// </remarks>
  public required string GlobalStylesPath { get; init; }

  /// <summary>
  /// Specifies the list of production dependencies required by the application.
  /// </summary>
  /// <remarks>
  /// This property outlines the essential dependencies that must be included
  /// for the application to function correctly. Each dependency is defined with
  /// its name and version, representing third-party or project-specific libraries
  /// needed in production environments.
  /// </remarks>
  public required DependencyDetails[] Dependencies { get; init; }

  /// <summary>
  /// Represents the development dependencies for the application.
  /// </summary>
  /// <remarks>
  /// This property includes a collection of development-specific dependencies
  /// necessary for tasks such as building, testing, or debugging the application.
  /// These dependencies are not required at runtime but are essential during the development lifecycle.
  /// </remarks>
  public required DependencyDetails[] DevDependencies { get; init; }
}
