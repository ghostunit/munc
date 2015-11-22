namespace Mp4UnCropper
{
  /// <summary>
  /// Provides information on where the fixed files should be stored, and how to modify their names.
  /// </summary>
  public class FileSaveRule
  {
    public FileSaveRule(string filenamePrefix, string filenameSuffix, string savePath)
    {
      this.FilenamePrefix = filenamePrefix;
      this.FilenameSuffix = filenameSuffix;
      this.SavePath = savePath;
    }

    internal string FilenamePrefix { get; private set; }

    internal string FilenameSuffix { get; private set; }
    
    internal string SavePath { get; private set; }

  }
}