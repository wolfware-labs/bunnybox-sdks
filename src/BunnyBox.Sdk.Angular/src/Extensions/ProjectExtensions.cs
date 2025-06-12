using BunnyBox.Sdk.Projects;

namespace BunnyBox.Sdk.Angular.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="Project"/> class, enabling additional functionality
/// related to managing project source folders and file operations within a BunnyBox project.
/// </summary>
public static class ProjectExtensions
{
  /// <summary>
  /// Populates the source folder in the BunnyBox project directory by copying project files
  /// from their original location while maintaining the folder structure. Optionally resets
  /// the source folder before copying the files.
  /// </summary>
  /// <param name="project">
  /// The <see cref="Project"/> instance representing the BunnyBox project for which to populate the source folder.
  /// </param>
  /// <param name="reset">
  /// A boolean flag indicating whether to reset the source folder before populating it.
  /// If true, the source folder is cleared before copying the files. Default value is false.
  /// </param>
  public static void PopulateSourceFolder(this Project project, bool reset = false)
  {
    if (reset)
    {
      project.BunnyBoxFolder.ResetSourceFolder();
    }

    foreach (var file in project.GetFiles().Where(x => !x.Contains("dist")))
    {
      project.CopyToSourceFolder(file);
    }
  }

  /// <summary>
  /// Copies a file or directory to the source folder of a BunnyBox project while maintaining its relative path.
  /// If the specified path points to a directory, it ensures the directory exists in the source folder.
  /// If the specified path points to a file, the file is copied into the source folder. Throws exceptions
  /// for invalid input or inaccessible paths.
  /// </summary>
  /// <param name="project">
  /// The <see cref="Project"/> instance representing the BunnyBox project where the source folder is located.
  /// </param>
  /// <param name="elementPath">
  /// The absolute path to the file or directory that needs to be copied to the project's source folder.
  /// The path must be within the project's root directory.
  /// </param>
  /// <exception cref="ArgumentException">
  /// Thrown when the provided <paramref name="elementPath"/> is null, empty, or does not reside within the
  /// project's directory.
  /// </exception>
  /// <exception cref="FileNotFoundException">
  /// Thrown when the provided <paramref name="elementPath"/> points to a file that does not exist.
  /// </exception>
  /// <exception cref="DirectoryNotFoundException">
  /// Thrown when the computed parent directory within the source folder cannot be accessed or created.
  /// </exception>
  public static void CopyToSourceFolder(this Project project, string elementPath)
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(elementPath, nameof(elementPath));

    if (Path.IsPathRooted(elementPath) &&
        !elementPath.StartsWith(project.Path, StringComparison.OrdinalIgnoreCase))
    {
      throw new ArgumentException("File or directory path must be within the project directory.", nameof(elementPath));
    }

    var newElementPath = Path.Combine(
      project.BunnyBoxFolder.GetSourceFolderPath(),
      Path.GetRelativePath(project.Path, elementPath)
    );

    if (Directory.Exists(elementPath))
    {
      if (!Directory.Exists(newElementPath))
      {
        Directory.CreateDirectory(newElementPath);
      }

      return;
    }

    if (!File.Exists(elementPath))
    {
      throw new FileNotFoundException($"The file or directory '{elementPath}' does not exist.", elementPath);
    }

    if (!Directory.Exists(Path.GetDirectoryName(newElementPath)))
    {
      Directory.CreateDirectory(Path.GetDirectoryName(newElementPath)!);
    }

    File.Copy(elementPath, newElementPath, true);
  }

  /// <summary>
  /// Deletes a specified file or directory from the source folder of the BunnyBox project.
  /// </summary>
  /// <param name="project">
  /// The <see cref="Project"/> instance representing the BunnyBox project whose source folder is being modified.
  /// </param>
  /// <param name="elementPath">
  /// The absolute path of the file or directory to delete. The path must be located within the project directory,
  /// otherwise an exception is thrown.
  /// </param>
  public static void DeleteFromSourceFolder(this Project project, string elementPath)
  {
    ArgumentException.ThrowIfNullOrWhiteSpace(elementPath, nameof(elementPath));

    if (Path.IsPathRooted(elementPath) &&
        !elementPath.StartsWith(project.Path, StringComparison.OrdinalIgnoreCase))
    {
      throw new ArgumentException("File or directory path must be within the project directory.", nameof(elementPath));
    }

    var sourceElementPath = Path.Combine(
      project.BunnyBoxFolder.GetSourceFolderPath(),
      Path.GetRelativePath(project.Path, elementPath)
    );

    if (File.Exists(sourceElementPath))
    {
      File.Delete(sourceElementPath);
    }
    else if (Directory.Exists(sourceElementPath))
    {
      Directory.Delete(sourceElementPath, true);
    }
  }

  /// <summary>
  /// Retrieves the full path to the "pages" folder within the specified BunnyBox project directory.
  /// </summary>
  /// <param name="project">
  /// The <see cref="Project"/> instance representing the BunnyBox project for which to retrieve the "pages" folder path.
  /// </param>
  /// <returns>
  /// A string representing the absolute path to the "pages" folder within the project directory.
  /// </returns>
  public static string GetPagesFolderPath(this Project project)
  {
    return Path.Combine(project.Path, "pages");
  }

  /// <summary>
  /// Determines whether the specified file path corresponds to a page within the "pages" folder
  /// of the given BunnyBox project. A valid page is a file that exists within the "pages" folder
  /// relative to the project's root path.
  /// </summary>
  /// <param name="project">
  /// The <see cref="Project"/> instance representing the BunnyBox project within which the file path is checked.
  /// </param>
  /// <param name="filePath">
  /// The absolute file path of the item to check. This should be a file path which is validated
  /// against the "pages" folder of the project structure.
  /// </param>
  /// <returns>
  /// True if the file path corresponds to a valid page within the "pages" folder of the project; otherwise, false.
  /// </returns>
  public static bool IsPage(this Project project, string filePath)
  {
    var relativePath = Path.GetRelativePath(project.Path, filePath);
    return (relativePath.StartsWith($"pages{Path.DirectorySeparatorChar}") ||
            relativePath.StartsWith($"pages{Path.AltDirectorySeparatorChar}")) &&
           // Ensure the path does not represent a directory
           File.Exists(filePath);
  }
}
