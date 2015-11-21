using System;

namespace Mp4UnCropper
{
  internal class Destination
  {
    private string originalFilename;
    private FileSaveRule fileSaveRule;

    internal string Path
    {
      get  {  return CreateDestinationPath();   }
    }

    internal Destination(FileSaveRule fileSaveRule, string pathToModify)
    {
      this.originalFilename = pathToModify;
      this.fileSaveRule = fileSaveRule;
    }

    private string CreateDestinationPath()
    {
      string result = String.Empty;

      string originalFilename = System.IO.Path.GetFileNameWithoutExtension(this.originalFilename);
      string extension = System.IO.Path.GetExtension(this.originalFilename);

      result = this.fileSaveRule.SavePath;
      result += this.fileSaveRule.FilenamePrefix;
      result += originalFilename;
      result += this.fileSaveRule.FilenameSuffix;
      result += extension;

      return result;
    }

  }
}
