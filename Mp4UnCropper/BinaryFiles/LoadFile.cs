using System;
using System.IO;

namespace Mp4UnCropper
{
  internal class LoadFile : BinaryFile
  {
    internal LoadFile(string filename)
      : base()
    {
      Path = filename;
      Bytes = new byte[0];
      Result = FileResult.Undefined;
      LogPrefix = "LOAD RESULT:   ";
      Load();
    }

    private void Load()
    {
      CheckForProgramError();
      CheckForIllegalCharacters();
      ReadFileFromDisk();
      ConfirmSuccess();
    }

    private void ConfirmSuccess()
    {
      if (Result != FileResult.Undefined)
      {
        return;
      }

      if (Bytes != null && Bytes.Length > 0)
      {
        Logger.Info("{0} Success", LogPrefix);
        Result = FileResult.Success;
      }
    }

    private void ReadFileFromDisk()
    {
      if (Result != FileResult.Undefined)
      {
        return;
      }

      try
      {
        Bytes = File.ReadAllBytes(Path);
      }
      catch (FileNotFoundException)
      {
        Logger.Info("{0} Could not find the specified file.", LogPrefix);
        Result = FileResult.PathNotFound;
      }
    }

  }
}
