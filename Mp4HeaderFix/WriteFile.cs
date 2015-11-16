using System;
using System.IO;

namespace Mp4HeaderFix
{
  public class WriteFile
  {
    private byte[] fileAsBytes;
    private string filename;
    private WriteFileResult writeFileResult;

    public string Path
    {
      get
      {
        return this.filename;
      }
    }

    internal byte[] Bytes
    {
      get
      {
        return fileAsBytes;
      }
    }

    public WriteFileResult Result
    {
      get
      {
        return writeFileResult;
      }
    }

    public WriteFile(byte[] fileAsBytes, string filename)
    {
      this.filename = filename;
      this.fileAsBytes = fileAsBytes;
      this.writeFileResult = WriteFileResult.Undefined;
      Save();
    }

    private void Save()
    {
      if (this.writeFileResult != WriteFileResult.Undefined)
      {
        return;
      }

      if (this.fileAsBytes.Length <= 0)
      {
        this.writeFileResult = WriteFileResult.NoDataToSave;
        return;
      }

      try
      {
        System.IO.Path.GetFullPath(this.filename);
      }
      catch (Exception ex)
      {
        this.writeFileResult = WriteFileResult.IllegalFilename;
        return;
      }

      try
      {
        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(this.filename));
        FileStream fileStream = new FileStream(this.filename, FileMode.Create, FileAccess.Write);
        fileStream.Write(this.fileAsBytes, 0, this.fileAsBytes.Length);
        fileStream.Close();
      }
      catch (UnauthorizedAccessException ex)
      {
        this.writeFileResult = WriteFileResult.PermissionsDenied;
        return;
      }
      catch (Exception ex)
      {
        this.writeFileResult = WriteFileResult.UnknownError;
        return;
      }

      if (File.Exists(filename))
      {
        this.writeFileResult = WriteFileResult.Success;
      }
    }

  }
}
