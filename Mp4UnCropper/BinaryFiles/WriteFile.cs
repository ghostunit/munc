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
      CheckForProgramError();
      EnsureNonEmptyByteArray();
      CheckForIllegalCharacters();
      WriteFileToDisk();
      ConfirmSuccess();
    }

    private void EnsureNonEmptyByteArray()
    {
      if (Result != FileResult.Undefined)
      {
        return;
      }

      if (Bytes == null || Bytes.Length <= 0)
      {
        Logger.Info("{0} There provided data was empty, therefore there was no data to save.", LogPrefix);
        Result = FileResult.NoDataToSave;
      }
    }

    private void WriteFileToDisk()
    {
      if (Result != FileResult.Undefined)
      {
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
      }
      catch (Exception)
      {
        Logger.Info("{0} An unexpected error occurred while trying to save the file.", LogPrefix);
        Result = FileResult.UnknownError;
      }
    }

    private void ConfirmSuccess()
    {
      if (Result != FileResult.Undefined)
      {
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
