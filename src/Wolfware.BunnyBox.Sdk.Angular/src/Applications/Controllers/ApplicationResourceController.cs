using Wolfware.BunnyBox.Sdk.Resources;
using Wolfware.BunnyBox.Sdk.Resources.Abstractions;

namespace Wolfware.BunnyBox.Sdk.Angular.Applications.Controllers;

internal class ApplicationResourceController : IResourceController
{
  /// <inheritdoc />
  public Task Handle(Resource resource, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }
}
