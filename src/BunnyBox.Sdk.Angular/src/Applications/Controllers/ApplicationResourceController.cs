using BunnyBox.Sdk.Resources;
using BunnyBox.Sdk.Resources.Abstractions;

namespace BunnyBox.Sdk.Angular.Applications.Controllers;

internal class ApplicationResourceController : IResourceController
{
  /// <inheritdoc />
  public Task Handle(Resource resource, CancellationToken cancellationToken = default)
  {
    throw new NotImplementedException();
  }
}
