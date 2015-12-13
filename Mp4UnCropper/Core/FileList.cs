using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mp4UnCropper
{
  internal class FileList
  {
    private string path;
    private List<string> fileLocationList;
    private FileResult fileResult;

    internal FileList(string path)
    {
      this.path = path;
      this.fileLocationList = new List<string>();
      this.fileResult = FileResult.Undefined;
      LoadFileList();
    }

    internal int Length
    {
      get
      {
        return fileLocationList.Count;
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

    private void LoadFileList()
    {
      try
      {
        Path.GetFullPath(path);
      }
      catch (Exception)
      {
        fileLocationList = new List<string> { path };
        fileResult = FileResult.IllegalFilename;
        return;
      }

      try
      {
        FileAttributes fileAttributes = File.GetAttributes(path);
        if (!fileAttributes.HasFlag(FileAttributes.Directory))
        {
          fileLocationList = new List<string> { path };
          fileResult = FileResult.Success;
          return;
        }
      }
      catch (FileNotFoundException)
      {
        fileLocationList = new List<string> { path };
        fileResult = FileResult.PathNotFound;
        return;
      }
      catch (Exception)
      {
        fileLocationList = new List<string> { path };
        fileResult = FileResult.UnknownError;
        return;
      }

      if (!Directory.Exists(path))
      {
        fileLocationList = new List<string> { path };
        fileResult = FileResult.PathNotFound;
        return;
      }

      try
      {
        fileLocationList = Directory.GetFiles(path, "*.mp4").ToList<string>();
      }
      catch (Exception)
      {
        fileLocationList = new List<string> { path };
        fileResult = FileResult.UnknownError;
        return;
      }

      fileResult = FileResult.Success;
    }

  }
}