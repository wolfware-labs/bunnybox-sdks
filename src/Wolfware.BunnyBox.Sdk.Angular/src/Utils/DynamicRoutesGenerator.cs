using System.Text.RegularExpressions;
using Wolfware.BunnyBox.Sdk.Angular.Extensions;
using Wolfware.BunnyBox.Sdk.Extensions;
using Wolfware.BunnyBox.Sdk.Projects;
using Wolfware.BunnyBox.Sdk.Angular.Applications.Templates.BunnyBoxFolder;

namespace Wolfware.BunnyBox.Sdk.Angular.Utils;

/// <summary>
/// Provides functionality for dynamically generating route details based on files in a specified directory.
/// </summary>
/// <remarks>
/// This utility scans the specified folder path for TypeScript files, extracts class names using a regex pattern,
/// and maps these to logical and physical paths for routing purposes. It is intended for use with Angular projects
/// to streamline the creation of routes.
/// </remarks>
internal static partial class DynamicRoutesGenerator
{
  public static RouteDetails[] GenerateRoutes(Project project)
  {
    var files = Directory.GetFiles(project.GetPagesFolderPath(), "*.ts", SearchOption.AllDirectories);
    files = files
      .Where(file => !file.EndsWith(".spec.ts", StringComparison.OrdinalIgnoreCase))
      .Where(file => !file.EndsWith(".d.ts", StringComparison.OrdinalIgnoreCase))
      .ToArray();

    if (files.Length == 0)
    {
      return [];
    }

    files = SortFilesForRoutes(files);

    var routes = new List<RouteDetails>(files.Length);

    var sourceFolderPath = Path.GetRelativePath(
      project.BunnyBoxFolder.Path,
      project.BunnyBoxFolder.GetSourceFolderPath()
    );

    foreach (var file in files)
    {
      var fileContent = File.ReadAllText(file);
      var componentNameRegex = DynamicRoutesGenerator.GetComponentClassNameRegex();
      var match = componentNameRegex.Match(fileContent);
      if (!match.Success)
      {
        continue;
      }

      foreach (var logicalPath in DynamicRoutesGenerator.GetLogicalPaths(project, file))
      {
        routes.Add(new RouteDetails
        {
          LogicalPath = logicalPath,
          PhysicalPath = DynamicRoutesGenerator.GetPhysicalPath(project, file, sourceFolderPath),
          Component = match.Groups["componentClassName"].Value,
        });
      }
    }

    return routes.ToArray();
  }

  private static string[] SortFilesForRoutes(string[] files)
  {
    // Sort files to ensure that 'index' files are processed last.
    var indexFile = files.FirstOrDefault(file =>
      Path.GetFileNameWithoutExtension(file).Equals("index", StringComparison.OrdinalIgnoreCase));
    if (indexFile is not null)
    {
      files = files.Where(file => file != indexFile).Concat([indexFile]).ToArray();
    }

    // Sort by directory depth, ensuring that deeper directories are processed first.
    Array.Sort(files, (file1, file2) =>
    {
      var depth1 = file1.Split(Path.DirectorySeparatorChar).Length;
      var depth2 = file2.Split(Path.DirectorySeparatorChar).Length;
      return depth1.CompareTo(depth2);
    });

    return files;
  }

  private static IEnumerable<string> GetLogicalPaths(Project project, string fileFullPath)
  {
    var relativePath = Path.GetRelativePath(project.GetPagesFolderPath(), fileFullPath);
    var logicalPath = Path.GetDirectoryName(relativePath)?.ToKebabCase() ?? string.Empty;

    var rawFileName = Path.GetFileNameWithoutExtension(relativePath);
    var logicalPageNames = DynamicRoutesGenerator.GetLogicalPageNames(rawFileName);
    foreach (var logicalPageName in logicalPageNames)
    {
      yield return Path.Combine(logicalPath, logicalPageName).Replace(Path.DirectorySeparatorChar, '/');
    }
  }

  private static string GetPhysicalPath(Project project, string file, string sourceFolderPath)
  {
    var pageRelativePath = Path.GetRelativePath(project.Path, Path.GetDirectoryName(file) ?? string.Empty);
    var pageFileName = Path.GetFileNameWithoutExtension(file);
    return Path.Combine("./", sourceFolderPath, pageRelativePath, pageFileName)
      .Replace(Path.DirectorySeparatorChar, '/');
  }

  private static IEnumerable<string> GetLogicalPageNames(string rawFileName)
  {
    if (rawFileName.Equals("index", StringComparison.OrdinalIgnoreCase))
    {
      yield return string.Empty;
      yield break;
    }

    var pageRouteDetailsRegex = DynamicRoutesGenerator.GetPageRouteDetailsRegex();
    var match = pageRouteDetailsRegex.Match(rawFileName);
    if (!match.Success)
    {
      throw new InvalidOperationException(
        $"Invalid page route details format in file name: {rawFileName}. Expected format: {{placeholder}} or logicName."
      );
    }

    foreach (var group in match.Groups.Values)
    {
      if (!group.Success)
      {
        continue;
      }

      if (group.Name.StartsWith("placeholder", StringComparison.OrdinalIgnoreCase))
      {
        yield return $":{group.Value}";
      }
      else if (group.Name.StartsWith("logicName", StringComparison.OrdinalIgnoreCase))
      {
        yield return group.Value.ToKebabCase();
      }
    }
  }

  [GeneratedRegex("""export class (?<componentClassName>[^\s]+)""", RegexOptions.Singleline)]
  private static partial Regex GetComponentClassNameRegex();

  [GeneratedRegex("""^(?:(?:\{(?<placeholder>[^}]+)\}|(?<logicName>[^{},]+)),?)+$""", RegexOptions.Singleline)]
  private static partial Regex GetPageRouteDetailsRegex();
}
