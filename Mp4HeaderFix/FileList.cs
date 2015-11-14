using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Mp4HeaderFix
{
  public class FileList
  {
    private string path;
    private List<string> fileLocationList;
    private ReadFileResult readFileResult;

    public int Length
    {
      get
      {
        return this.fileLocationList.Count;
      }
    }

    public List<string> Files
    {
      get
      {
        return fileLocationList;
      }
    }

    public ReadFileResult Result
    {
      get
      {
        return readFileResult;
      }
    }

    public FileList(string path)
    {
      this.path = path;
      LoadFileList();
    }

    private void LoadFileList()
    {
      try
      {
        Path.GetFullPath(this.path);
      }
      catch (Exception ex)
      {
        readFileResult = ReadFileResult.IllegalFilename;
        return;
      }

      FileAttributes fileAttributes = File.GetAttributes(this.path);
      if (!fileAttributes.HasFlag(FileAttributes.Directory))
      {
        fileLocationList = new List<string> { this.path };
        this.readFileResult = ReadFileResult.Success;
        return;
      }

      if (!Directory.Exists(this.path))
      {
        this.readFileResult = ReadFileResult.PathNotFound;
        return;
      }

      try
      {
        this.fileLocationList = Directory.GetFiles(this.path).ToList<string>();
      }
      catch (Exception ex)
      {
        readFileResult = ReadFileResult.UnknownError;
        return;
      }

      readFileResult = ReadFileResult.Success;
    }

  }
}




