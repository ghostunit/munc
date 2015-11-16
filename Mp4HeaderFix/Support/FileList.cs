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
    private FileResult fileResult;

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

    internal FileResult Result
    {
      get
      {
        return fileResult;
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
        fileResult = FileResult.IllegalFilename;
        return;
      }

      FileAttributes fileAttributes = File.GetAttributes(this.path);
      if (!fileAttributes.HasFlag(FileAttributes.Directory))
      {
        fileLocationList = new List<string> { this.path };
        this.fileResult = FileResult.Success;
        return;
      }

      if (!Directory.Exists(this.path))
      {
        this.fileResult = FileResult.PathNotFound;
        return;
      }

      try
      {
        this.fileLocationList = Directory.GetFiles(this.path).ToList<string>();
      }
      catch (Exception ex)
      {
        fileResult = FileResult.UnknownError;
        return;
      }

      fileResult = FileResult.Success;
    }

  }
}