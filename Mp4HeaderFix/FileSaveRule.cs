
namespace Mp4HeaderFix
{
  public class FileSaveRule
  {
    private string filenamePrefix;
    private string filenameSuffix;
    private string savePath;

    public string FilenamePrefix
    {
      get
      {
        return this.filenamePrefix;
      }
    }

    public string FilenameSuffix
    {
      get
      {
        return this.filenameSuffix;
      }
    }

    public string SavePath
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
