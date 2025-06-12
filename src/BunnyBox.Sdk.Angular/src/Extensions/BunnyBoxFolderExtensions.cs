using BunnyBox.Sdk.Projects.Abstractions;

namespace BunnyBox.Sdk.Angular.Extensions;

/// <summary>
/// Provides extension methods for working with BunnyBox folders.
/// </summary>
public static class BunnyBoxFolderExtensions
{
  /// <summary>
  /// Retrieves the path to the source folder ("src") within a BunnyBox folder.
  /// </summary>
  /// <param name="bunnyBoxFolder">The BunnyBox folder for which to retrieve the source folder path.</param>
  /// <returns>The full path to the source folder.</returns>
  public static string GetSourceFolderPath(this IBunnyBoxFolder bunnyBoxFolder)
  {
    return Path.Combine(bunnyBoxFolder.Path, "src");
  }

  /// <summary>
  /// Deletes the source folder ("src") within a BunnyBox folder if it exists.
  /// </summary>
  /// <param name="bunnyBoxFolder">The BunnyBox folder from which to delete the source folder.</param>
  public static void DeleteSourceFolder(this IBunnyBoxFolder bunnyBoxFolder)
  {
    var sourceTargetPath = bunnyBoxFolder.GetSourceFolderPath();
    if (Directory.Exists(sourceTargetPath))
    {
      Directory.Delete(sourceTargetPath, true);
    }
  }

  /// <summary>
  /// Creates the source folder ("src") within a BunnyBox folder if it does not already exist.
  /// </summary>
  /// <param name="bunnyBoxFolder">The BunnyBox folder within which to create the source folder.</param>
  public static void CreateSourceFolder(this IBunnyBoxFolder bunnyBoxFolder)
  {
    var sourceTargetPath = bunnyBoxFolder.GetSourceFolderPath();
    if (!Directory.Exists(sourceTargetPath))
    {
      Directory.CreateDirectory(sourceTargetPath);
    }
  }

  /// <summary>
  /// Resets the source folder ("src") within a BunnyBox folder by deleting it if it exists
  /// and then recreating it as an empty folder.
  /// </summary>
  /// <param name="bunnyBoxFolder">The BunnyBox folder for which to reset the source folder.</param>
  public static void ResetSourceFolder(this IBunnyBoxFolder bunnyBoxFolder)
  {
    bunnyBoxFolder.DeleteSourceFolder();
    bunnyBoxFolder.CreateSourceFolder();
  }
}
