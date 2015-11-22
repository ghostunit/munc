using System;
using System.IO;

namespace Mp4UnCropper
{
  internal class WriteFile : BinaryFile
  {
    internal WriteFile(BinaryFile binaryFile)
      : base()
    {
      Path = binaryFile.Path;
      Bytes = binaryFile.Bytes;
      Result = FileResult.Undefined;
      LogPrefix = "SAVE RESULT:   ";
      Save();
    }

    private void Save()
    {
      if (Result != FileResult.Undefined)
      {
        Logger.Info("{0} An unexpected error occurred while trying to save the file.", LogPrefix);
        return;
      }

      if (Bytes == null || Bytes.Length <= 0)
      {
        Logger.Info("{0} There provided data was empty, therefore there was no data to save.", LogPrefix);
        Result = FileResult.NoDataToSave;
        return;
      }

      try
      {
        System.IO.Path.GetFullPath(Path);
      }
      catch (Exception)
      {
        Logger.Info("{0} Could not save the file because it's name contained illegal characters.", LogPrefix);
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
        Logger.Info("{0} Could not save the file because of a permissions error.", LogPrefix);
        Result = FileResult.PermissionFailure;
        return;
      }
      catch (Exception)
      {
        Logger.Info("{0} An unexpected error occurred while trying to save the file.", LogPrefix);
        Result = FileResult.UnknownError;
        return;
      }

      if (File.Exists(Path))
      {
        Logger.Info("{0} Success", LogPrefix);
        Result = FileResult.Success;
      }
    }

  }
}
