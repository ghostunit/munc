using System;
using System.Collections.Generic;
using System.IO;

namespace Mp4HeaderFix
{
  public class Mp4RepairJob
  {
    private string pathToOriginalFiles;
    private Dimension oldDimensions;
    private Dimension newDimensions;
    private FileSaveRule fileSaveRule;
    private List<LoadFile> loadFailures;
    private List<WriteFile> writeFailures;

    public List<LoadFile> LoadFailures
    {
      get
      {
        return this.loadFailures;
      }
    }

    public List<WriteFile> WriteFailures
    {
      get
      {
        return this.writeFailures;
      }
    }

    public Mp4RepairJob(string pathToOriginalFiles, Dimension oldDimensions, Dimension newDimensions, FileSaveRule fileSaveRule)
    {
      this.pathToOriginalFiles = pathToOriginalFiles;
      this.oldDimensions = oldDimensions;
      this.newDimensions = newDimensions;
      this.fileSaveRule = fileSaveRule;
      this.loadFailures = new List<LoadFile>();
      this.writeFailures = new List<WriteFile>();
    }

    public Dictionary<string, string> Run()
    {
      Dictionary<string, string> result = new Dictionary<string, string>();

      List<string> filenames = new FileList(this.pathToOriginalFiles).Files;
      foreach (string filename in filenames)
      {
        bool success = true;

        LoadFile loadFile = new LoadFile(filename);
        if (loadFile.Result != ReadFileResult.Success)
        {
          this.loadFailures.Add(loadFile);
          success = false;
        }

        ModifiedFile modifiedFile = new ModifiedFile(loadFile.Bytes, this.oldDimensions.AsBytes, this.newDimensions.AsBytes);

        

        string newFilename = CreateDestinationPath(filename);
        WriteFile writeFile = new WriteFile(modifiedFile.Bytes, newFilename);
        if (writeFile.Result != WriteFileResult.Success)
        {
          this.writeFailures.Add(writeFile);
          success = false;
        }

        if (success)
        {
          result.Add(loadFile.Path, writeFile.Path);
        }
      }

      return result;
    }

    private string CreateDestinationPath(string pathToModify)
    {
      string result = String.Empty;
      string originalFilename = Path.GetFileNameWithoutExtension(pathToModify);
      string extension = Path.GetExtension(pathToModify);

      result = this.fileSaveRule.SavePath;
      result += this.fileSaveRule.FilenamePrefix;
      result += originalFilename;
      result += this.fileSaveRule.FilenameSuffix;
      result += extension;
      
      return result;
    }

  }
}
