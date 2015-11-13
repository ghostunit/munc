using System;
using System.IO;

namespace Mp4HeaderFix
{
  public class LoadFile
  {
    private string filename;
    private byte[] fileAsBytes;
    private FileLoadResult fileLoadResult;

    public FileLoadResult Result
    {
      get
      {
        Load();
        return this.fileLoadResult;
      }
    }

    public byte[] Bytes
    {
      get
      {
        Load();
        return this.fileAsBytes;
      }
    }

    public LoadFile(string filename)
    {
      this.filename = filename;
      this.fileAsBytes = new byte[0];
      this.fileLoadResult = FileLoadResult.Undefined;
    }

    private void Load()
    {
      if (this.fileLoadResult != FileLoadResult.Undefined)
      {
        return;
      }

      try
      {
        Path.GetFullPath(this.filename);
      }
      catch (Exception ex)
      {
        this.fileLoadResult = FileLoadResult.IllegalFilename;
        return;
      }

      try
      {
        this.fileAsBytes = File.ReadAllBytes(this.filename);
      }
      catch (FileNotFoundException ex)
      {
        this.fileLoadResult = FileLoadResult.FileNotFound;
        return;
      }

      if (this.fileAsBytes != null && this.fileAsBytes.Length > 0)
      {
        this.fileLoadResult = FileLoadResult.Loaded;
      }
    }

  }
}
