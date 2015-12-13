using System;
using NLog;

namespace Mp4UnCropper
{
  internal class BinaryFile
  {
    protected BinaryFile()
    {
      Logger = LogManager.GetLogger(GetType().FullName);
    }

    protected internal string Path { get; protected set; }

    protected internal byte[] Bytes { get; protected set; }

    protected internal FileResult Result { get; protected set; }

    protected Logger Logger { get; private set; }

    protected string LogPrefix { get; set; }

    protected void CheckForProgramError()
    {
      if (Result != FileResult.Undefined)
      {
        Logger.Info("{0} An unexpected error occurred while workign with the file.", LogPrefix);
        return;
      }
    }

    protected void CheckForIllegalCharacters()
    {
      if (Result != FileResult.Undefined)
      {
        return;
      }

      try
      {
        System.IO.Path.GetFullPath(Path);
      }
      catch (Exception)
      {
        Logger.Info("{0} Folder or file path contained illegal characters.", LogPrefix);
        Result = FileResult.IllegalFilename;
      }
    }

  }
}