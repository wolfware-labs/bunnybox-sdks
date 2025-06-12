using BunnyBox.Sdk.Extensions;
using BunnyBox.Sdk.Projects.Abstractions;
using Json.Schema;

namespace BunnyBox.Sdk.Angular.MicroFrontends.Definitions;

/// <summary>
/// Defines a project type named "MicroFrontend" as part of the BunnyBox SDK Angular module.
/// Implements the <see cref="IProjectDefinition"/> interface.
/// </summary>
/// <remarks>
/// This class provides the implementation for working with a MicroFrontend project definition,
/// including the capability to retrieve a schema and create a default project manifest.
/// </remarks>
internal class MicroFrontendProjectDefinition : IProjectDefinition
{
  /// <summary>
  /// Retrieves the schema definition for the MicroFrontend project.
  /// </summary>
  /// <returns>
  /// A string representation of the schema for the MicroFrontend project.
  /// </returns>
  public Task<JsonSchema> GetSchema()
  {
    return this.GetType().Assembly.GetSchemaFromResource(
      "BunnyBox.Sdk.Angular.src.MicroFrontends.Schemas.project.schema.json"
    );
  }
}
