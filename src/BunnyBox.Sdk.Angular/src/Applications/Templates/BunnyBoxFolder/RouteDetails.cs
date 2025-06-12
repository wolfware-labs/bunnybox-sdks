namespace BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;

/// <summary>
/// Represents the details of a route in the Angular application template.
/// </summary>
/// <remarks>
/// This class is typically used to store and manage route-related information,
/// including the logical path, physical path, and associated component for a given route.
/// The route details are utilized in rendering or configuring Angular applications.
/// </remarks>
internal sealed class RouteDetails
{
  /// <summary>
  /// Gets the logical path representation of a route.
  /// </summary>
  /// <remarks>
  /// The logical path corresponds to the URL-friendly identifier of the route,
  /// typically generated from a folder or file structure and formatted in kebab case.
  /// It is primarily used to define or reference routes in the Angular application.
  /// </remarks>
  public required string LogicalPath { get; init; }

  /// <summary>
  /// Gets the physical path representation of a route file.
  /// </summary>
  /// <remarks>
  /// The physical path refers to the file system location of the route,
  /// expressed in a format relative to the project's root. It is used to locate
  /// the route's corresponding file during rendering or configuration in the Angular application.
  /// </remarks>
  public required string PhysicalPath { get; init; }

  /// <summary>
  /// Gets the name of the Angular component associated with the route.
  /// </summary>
  /// <remarks>
  /// The component is a TypeScript class name that represents an Angular component
  /// defined within the application. It is extracted from the source files of the
  /// specified pages folder and is used when configuring routes dynamically in the
  /// application. This property is essential for linking a specific Angular component
  /// to its corresponding route.
  /// </remarks>
  public required string Component { get; init; }
}
