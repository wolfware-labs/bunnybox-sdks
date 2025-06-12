using BunnyBox.Sdk.Resources;
using BunnyBox.Sdk.Resources.Abstractions;

namespace BunnyBox.Sdk.Angular.MicroFrontends.Controllers;

/// <summary>
/// Represents a resource controller specifically for managing micro-frontend resources
/// within the BunnyBox Angular SDK.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IResourceController"/> interface and provides logic
/// for handling resources associated with micro-frontends in the ecosystem.
/// </remarks>
internal class MicroFrontendResourceController : IResourceController
{
  public Task Handle(Resource resource, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }
}
