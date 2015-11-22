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
      if (Result != FileResult.Undefined)
      {
        Logger.Info("{0} An unexpected error occurred while trying to load the file.", LogPrefix);
        return;
      }

      try
      {
        System.IO.Path.GetFullPath(Path);
      }
      catch (Exception)
      {
        Logger.Info("{0} Could not load the original folder or file because it contained illegal characters.", LogPrefix);
        Result = FileResult.IllegalFilename;
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
        return;
      }

      if (Bytes != null && Bytes.Length > 0)
      {
        Logger.Info("{0} Success", LogPrefix);
        Result = FileResult.Success;
      }
    }
  }
}
