
namespace Mp4HeaderFix
{
  public class FileSaveRule
  {
    private string filenamePrefix;
    private string filenameSuffix;
    private string savePath;

    internal string FilenamePrefix
    {
      get
      {
        return this.filenamePrefix;
      }
    }

    internal string FilenameSuffix
    {
      get
      {
        return this.filenameSuffix;
      }
    }

    internal string SavePath
    {
      get
      {
        return this.savePath;
      }
    }

    public FileSaveRule(string filenamePrefix, string filenameSuffix, string savePath)
    {
      this.filenamePrefix = filenamePrefix;
      this.filenameSuffix = filenameSuffix;
      this.savePath = savePath;
    }
  }
}
