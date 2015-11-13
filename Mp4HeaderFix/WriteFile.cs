using System;
using System.IO;

namespace Mp4HeaderFix
{
  public class WriteFile
  {
    private byte[] fileAsBytes;
    private string filename;
    private FileWriteResult fileWriteResult;

    public byte[] Bytes
    {
      get
      {
        return fileAsBytes;
      }
    }

    public FileWriteResult Result
    {
      get
      {
        return fileWriteResult;
      }
    }

    public WriteFile(byte[] fileAsBytes, string filename)
    {
      this.filename = filename;
      this.fileAsBytes = fileAsBytes;
    }

    private void Save()
    {
      if (this.fileWriteResult != FileWriteResult.Undefined)
      {
        return;
      }

      if (this.fileAsBytes.Length <= 0)
      {
        this.fileWriteResult = FileWriteResult.NoDataToSave;
        return;
      }

      try
      {
        Path.GetFullPath(this.filename);
      }
      catch (Exception ex)
      {
        this.fileWriteResult = FileWriteResult.IllegalFilename;
        return;
      }

      try
      {
        FileStream fileStream = new FileStream(this.filename, FileMode.Create, FileAccess.Write);
        fileStream.Write(this.fileAsBytes, 0, this.fileAsBytes.Length);
        fileStream.Close();
      }
      catch (UnauthorizedAccessException ex)
      {
        this.fileWriteResult = FileWriteResult.PermissionsDenied;
        return;
      }

      if (File.Exists(filename))
      {
        this.fileWriteResult = FileWriteResult.Saved;
      }
    }

  }
}
