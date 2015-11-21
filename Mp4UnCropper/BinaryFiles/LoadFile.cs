using System;
using System.IO;

namespace Mp4UnCropper
{
  internal class LoadFile : BinaryFile
  {
    internal LoadFile(string filename)
    {
      this.filename = filename;
      this.fileAsBytes = new byte[0];
      this.fileResult = FileResult.Undefined;
      Load();
    }

    private void Load()
    {
      if (this.fileResult != FileResult.Undefined)
      {
        return;
      }

      try
      {
        System.IO.Path.GetFullPath(this.filename);
      }
      catch (Exception)
      {
        this.fileResult = FileResult.IllegalFilename;
        return;
      }

      try
      {
        this.fileAsBytes = File.ReadAllBytes(this.filename);
      }
      catch (FileNotFoundException)
      {
        this.fileResult = FileResult.PathNotFound;
        return;
      }

      if (this.fileAsBytes != null && this.fileAsBytes.Length > 0)
      {
        this.fileResult = FileResult.Success;
      }
    }
  }
}
