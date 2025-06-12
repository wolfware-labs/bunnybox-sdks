using System.Reflection;
using BunnyBox.Sdk.Abstractions;
using BunnyBox.Sdk.Angular.Applications.Controllers;
using BunnyBox.Sdk.Angular.Applications.Definitions;
using BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;
using BunnyBox.Sdk.Angular.Applications.Templates.Project;
using BunnyBox.Sdk.Angular.Interop;
using BunnyBox.Sdk.Angular.Interop.Abstractions;
using BunnyBox.Sdk.Angular.MicroFrontends.Controllers;
using BunnyBox.Sdk.Angular.MicroFrontends.Definitions;
using BunnyBox.Sdk.Extensions;
using BunnyBox.Sdk.NodeJs.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BunnyBox.Sdk.Angular;

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
