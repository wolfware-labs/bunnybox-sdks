using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.Resources;
using Wolfware.BunnyBox.Sdk.Resources.Abstractions;
using Json.Schema;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Definitions;

/// <summary>
/// Represents a resource definition for an application.
/// This class provides functionality for retrieving the schema of the resource
/// and creating a default resource instance.
/// </summary>
/// <remarks>
/// This class is used within the BunnyBox SDK to register and manage application-specific
/// resources. It is an implementation of the <see cref="IResourceDefinition"/> interface
/// and provides a concrete representation of an application resource.
/// </remarks>
internal sealed class ApplicationResourceDefinition : IResourceDefinition
{
  /// <summary>
  /// Represents the name of the resource associated with the ApplicationResourceDefinition.
  /// </summary>
  /// <remarks>
  /// This constant is utilized throughout the BunnyBox SDK to register and manage resources
  /// related to the "Application" resource type. It serves as an identifier within the context
  /// of resource management operations.
  /// </remarks>
  public const string ResourceName = "Application";

  /// <summary>
  /// Asynchronously retrieves and returns the JSON Schema associated with the application resource definition.
  /// </summary>
  /// <returns>
  /// A <see cref="JsonSchema"/> object representing the structure and constraints of the application resource.
  /// </returns>
  public Task<JsonSchema> GetSchema()
  {
    return this.GetType().Assembly.GetSchemaFromResource(
      "Wolfware.BunnyBox.Sdk.Angular.src.Applications.Schemas.resource.schema.json"
    );
  }

  /// <summary>
  /// Creates and returns a default instance of the resource associated with the application.
  /// </summary>
  /// <returns>
  /// A <see cref="Resource"/> object representing the default state of the application resource.
  /// </returns>
  public Resource CreateDefault()
  {
    throw new NotImplementedException();
  }
}
