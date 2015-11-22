namespace Mp4UnCropper
{
  /// <summary>Provides information on where the fixed files should be stored, and how to modify their names.</summary>
  public class FileSaveRule
  {
    /// <summary>Initializes a new instance of the <see cref="FileSaveRule"/> class.</summary>
    /// <param name="filenamePrefix">The characters to precede the filename when saved</param>
    /// <param name="filenameSuffix">The trailing characters to be appended to the filename when saved</param>
    /// <param name="savePath">The directory to save all repaired files in</param>
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