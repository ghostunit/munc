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

    private void LoadFileList()
    {
      try
      {
        Path.GetFullPath(this.path);
      }
      catch (Exception)
      {
        this.fileLocationList = new List<string> { this.path };
        this.fileResult = FileResult.IllegalFilename;
        return;
      }

      try
      {
        FileAttributes fileAttributes = File.GetAttributes(this.path);
        if (!fileAttributes.HasFlag(FileAttributes.Directory))
        {
          this.fileLocationList = new List<string> { this.path };
          this.fileResult = FileResult.Success;
          return;
        }
      }
      catch (FileNotFoundException)
      {
        this.fileLocationList = new List<string> { this.path };
        this.fileResult = FileResult.PathNotFound;
        return;
      }
      catch (Exception)
      {
        this.fileLocationList = new List<string> { this.path };
        this.fileResult = FileResult.UnknownError;
        return;
      }

      if (!Directory.Exists(this.path))
      {
        this.fileLocationList = new List<string> { this.path };
        this.fileResult = FileResult.PathNotFound;
        return;
      }

      try
      {
        this.fileLocationList = Directory.GetFiles(this.path, "*.mp4").ToList<string>();
      }
      catch (Exception)
      {
        this.fileLocationList = new List<string> { this.path };
        this.fileResult = FileResult.UnknownError;
        return;
      }

      this.fileResult = FileResult.Success;
    }

  }
}