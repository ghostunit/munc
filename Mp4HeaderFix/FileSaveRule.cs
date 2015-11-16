namespace Mp4HeaderFix
{
  /// <summary>
  /// Provides information on where the fixed files should be stored, and how to modify their names.
  /// </summary>
  public class FileSaveRule
  {
    internal string FilenamePrefix { get; private set; }
    internal string FilenameSuffix { get; private set; }
    internal string SavePath { get; private set; }

    public FileSaveRule(string filenamePrefix, string filenameSuffix, string savePath)
    {
      FilenamePrefix = filenamePrefix;
      FilenameSuffix = filenameSuffix;
      SavePath = savePath;
    }
  }
}
