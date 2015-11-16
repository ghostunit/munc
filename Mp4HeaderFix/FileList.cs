using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Mp4HeaderFix
{
  internal class FileList
  {
    private string path;
    private List<string> fileLocationList;
    private ReadFileResult readFileResult;

    internal int Length
    {
      get
      {
        return this.fileLocationList.Count;
      }
    }

    internal List<string> Files
    {
      get
      {
        return fileLocationList;
      }
    }

    internal ReadFileResult Result
    {
      get
      {
        return readFileResult;
      }
    }

    internal FileList(string path)
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




