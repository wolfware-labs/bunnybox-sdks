using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.Projects.Abstractions;
using JsonSchema = Json.Schema.JsonSchema;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Definitions;

/// <summary>
/// Represents a project definition for the "Application" project type in the BunnyBox SDK Angular module.
/// Provides functionality to retrieve the schema for the project and to create a default project instance.
/// </summary>
internal sealed class ApplicationProjectDefinition : IProjectDefinition
{
  /// <summary>
  /// Asynchronously retrieves the JSON schema associated with the application project definition.
  /// </summary>
  /// <returns>
  /// A <see cref="JsonSchema"/> object representing the schema of the application project.
  /// </returns>
  public Task<JsonSchema> GetSchema()
  {
    return this.GetType().Assembly.GetSchemaFromResource(
      "Wolfware.BunnyBox.Sdk.Angular.src.Applications.Schemas.project.schema.json"
    );
  }
}
