using System.Reflection;
using Wolfware.BunnyBox.Sdk.Abstractions;
using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.NodeJs.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Controllers;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Definitions;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.Project;
using Wolfware.BunnyBox.Sdk.Angular.Interop;
using Wolfware.BunnyBox.Sdk.Angular.Interop.Abstractions;
using Wolfware.BunnyBox.Sdk.Angular.MicroFrontends.Controllers;
using Wolfware.BunnyBox.Sdk.Angular.MicroFrontends.Definitions;

namespace Wolfware.BunnyBox.Sdk.Angular;

public sealed class AngularSdkStartup : ISdkStartup
{
  private const string SdkName = "Angular";
  private static readonly Assembly _assembly = typeof(AngularSdkStartup).Assembly;

  public void Configure(IServiceCollection services)
  {
    services.AddNodeJsSdk();
    services.AddSingleton<ITargetRunner, TargetRunner>();
    services.AddMediatR(x => x.RegisterServicesFromAssembly(AngularSdkStartup._assembly));

    services.AddBunnyBoxSdk(
      AngularSdkStartup.SdkName,

      AngularSdkStartup._assembly.GetSemVer(),
      builder =>
      {
        // Register the Application resource with its project
        builder.AddResource<ApplicationResourceDefinition, ApplicationResourceController>(
          ApplicationResourceDefinition.ResourceName,
          resource => resource.WithProject<ApplicationProjectDefinition, ApplicationProjectController>(proj =>
          {
            proj.WithProjectTemplate<ApplicationProjectTemplateContext>("ApplicationProjectTemplate_");
            proj.WithBunnyBoxFolderTemplate<ApplicationFolderTemplateContext>("ApplicationFolderTemplate_");
            proj.WithFileTemplate<ApplicationMainFileTemplateContext>("ApplicationMainTemplate_");
          })
        );

        // Register the MicroFrontend resource with its project
        builder.AddResource<MicroFrontendResourceDefinition, MicroFrontendResourceController>(
          MicroFrontendResourceDefinition.ResourceName//,
          // resource => resource.WithProject<MicroFrontendProjectDefinition, MicroFrontendProjectController>(proj =>
          // {
          //   proj.WithProjectTemplate<MicrFrontendProjectTemplateContext>("MicroFrontendProjectTemplate_");
          //   proj.WithBunnyBoxFolderTemplate<MicroFrontendFolderTemplateContext>("MicroFrontendFolderTemplate_");
          // })
        );
      }
    );
  }
}
