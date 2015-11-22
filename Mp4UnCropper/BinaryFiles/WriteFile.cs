using System;
using System.IO;

namespace Mp4UnCropper
{
  internal class WriteFile : BinaryFile
  {
    internal WriteFile(BinaryFile binaryFile)
    {
      Path = binaryFile.Path;
      Bytes = binaryFile.Bytes;
      Result = FileResult.Undefined;
      Save();
    }

    private void Save()
    {
      if (Result != FileResult.Undefined)
      {
        return;
      }

      if (Bytes == null || Bytes.Length <= 0)
      {
        Result = FileResult.NoDataToSave;
        return;
      }

      try
      {
        System.IO.Path.GetFullPath(Path);
      }
      catch (Exception)
      {
        Result = FileResult.IllegalFilename;
        return;
      }

      try
      {
        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Path));
        FileStream fileStream = new FileStream(Path, FileMode.Create, FileAccess.Write);
        fileStream.Write(Bytes, 0, Bytes.Length);
        fileStream.Close();
      }
      catch (UnauthorizedAccessException)
      {
        Result = FileResult.PermissionFailure;
        return;
      }
      catch (Exception)
      {
        Result = FileResult.UnknownError;
        return;
      }

      if (File.Exists(Path))
      {
        Result = FileResult.Success;
      }
    }

  }
}
