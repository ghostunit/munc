using System;
using System.IO;

namespace Mp4HeaderFix
{
  internal class WriteFile : BinaryFile
  {
    internal WriteFile(BinaryFile binaryFile)
    {
      this.filename = binaryFile.Path;
      this.fileAsBytes = binaryFile.Bytes;
      this.fileResult = FileResult.Undefined;
      Save();
    }

    private void Save()
    {
      if (this.fileResult != FileResult.Undefined)
      {
        return;
      }

      if (this.fileAsBytes == null || this.fileAsBytes.Length <= 0)
      {
        this.fileResult = FileResult.NoDataToSave;
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
        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(this.filename));
        FileStream fileStream = new FileStream(this.filename, FileMode.Create, FileAccess.Write);
        fileStream.Write(this.fileAsBytes, 0, this.fileAsBytes.Length);
        fileStream.Close();
      }
      catch (UnauthorizedAccessException ex)
      {
        this.fileResult = FileResult.PermissionFailure;
        return;
      }
      catch (Exception ex)
      {
        this.fileResult = FileResult.UnknownError;
        return;
      }

      if (File.Exists(filename))
      {
        this.fileResult = FileResult.Success;
      }
    }

  }
}
