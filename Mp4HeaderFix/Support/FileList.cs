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
      this.fileLocationList = new List<string>();
      this.fileResult = FileResult.Undefined;
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
      catch (FileNotFoundException ex)
      {
        this.fileLocationList = new List<string> { this.path };
        this.fileResult = FileResult.PathNotFound;
        return;
      }
      catch (Exception ex)
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
      catch (Exception ex)
      {
        this.fileLocationList = new List<string> { this.path };
        this.fileResult = FileResult.UnknownError;
        return;
      }

      this.fileResult = FileResult.Success;
    }

  }
}