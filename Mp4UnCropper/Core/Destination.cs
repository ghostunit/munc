using System;

namespace Mp4UnCropper
{
  internal class Destination
  {
    private string originalFilename;
    private FileSaveRule fileSaveRule;

    internal Destination(FileSaveRule fileSaveRule, string pathToModify)
    {
      this.originalFilename = pathToModify;
      this.fileSaveRule = fileSaveRule;
    }

    internal string Path
    {
      get { return CreateDestinationPath(); }
    }

    private string CreateDestinationPath()
    {
      string result = String.Empty;

      string filenameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(originalFilename);
      string extension = System.IO.Path.GetExtension(filenameWithoutExtension);

      result = fileSaveRule.SavePath;
      result += fileSaveRule.FilenamePrefix;
      result += filenameWithoutExtension;
      result += fileSaveRule.FilenameSuffix;
      result += extension;

      return result;
    }

  }
}
