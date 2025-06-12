using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.Resources;
using Wolfware.BunnyBox.Sdk.Resources.Abstractions;
using Json.Schema;

namespace Wolfware.BunnyBox.Sdk.Angular.MicroFrontends.Definitions;

/// <summary>
/// Represents a resource definition for a micro-frontend in the context of the BunnyBox Angular SDK.
/// This class provides schema details and methods to create default resource instances associated
/// with micro-frontends. It implements the <see cref="IResourceDefinition"/> interface
/// to adhere to the standard structure for resource definitions.
/// The resource is identified with a constant resource name "MicroFrontend".
/// </summary>
internal sealed class MicroFrontendResourceDefinition : IResourceDefinition
{
  /// <summary>
  /// The constant identifier for the "MicroFrontend" resource type used in the BunnyBox Angular SDK.
  /// Represents the name of the resource associated with a micro-frontend.
  /// </summary>
  public const string ResourceName = "MicroFrontend";

  /// <summary>
  /// Retrieves the schema associated with the current resource definition.
  /// </summary>
  /// <returns>
  /// A string representation of the schema.
  /// </returns>
  public Task<JsonSchema> GetSchema()
  {
    return this.GetType().Assembly.GetSchemaFromResource(
      "Wolfware.BunnyBox.Sdk.Angular.src.MicroFrontends.Schemas.project.schema.json"
    );
  }

  /// <summary>
  /// Creates and returns a default resource instance for this resource definition.
  /// </summary>
  /// <returns>
  /// A new instance of the <see cref="Resource"/> class representing the default resource.
  /// </returns>
  public Resource CreateDefault()
  {
    throw new NotImplementedException();
  }
}
