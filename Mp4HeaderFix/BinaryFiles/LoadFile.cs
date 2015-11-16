using System;
using System.IO;

namespace Mp4HeaderFix
{
  internal class LoadFile : BinaryFile
  {
    public LoadFile(string filename)
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
      catch (Exception ex)
      {
        this.fileResult = FileResult.IllegalFilename;
        return;
      }

      try
      {
        this.fileAsBytes = File.ReadAllBytes(this.filename);
      }
      catch (FileNotFoundException ex)
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
