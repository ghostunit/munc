namespace Mp4UnCropper
{
  internal class ModifiedFile : BinaryFile
  {
    private byte[] originalFile;
    private byte[] oldData;
    private byte[] newData;

    internal ModifiedFile(byte[] originalFile, byte[] oldData, byte[] newData, string destinationFilename)
      : base()
    {
      this.originalFile = originalFile;
      this.oldData = oldData;
      this.newData = newData;
      Path = destinationFilename;
      Result = FileResult.Undefined;
      LogPrefix = "MODIFY RESULT: ";
      ReplaceBytes();
    }

    private void ReplaceBytes()
    {
      Bytes = originalFile;

      if (Bytes == null || Bytes.Length == 0)
      {
        Logger.Info("{0} The data provided was empty, therefore there was no file to modify.", LogPrefix);
        Bytes = new byte[0];
        Result = FileResult.NoFileToModify;
      }

      PatternMatch patternMatch = new PatternMatch(oldData, Bytes);
      if (!patternMatch.Success)
      {
        Logger.Info("{0} The dimensions provided were not found anywhere in the file.", LogPrefix);
        Bytes = new byte[0];
        Result = FileResult.PatternNotFound;
      }
      else
      {
        Logger.Info("{0} Success", LogPrefix);
        Result = FileResult.Success;
        Bytes[patternMatch.Index] = newData[0];
        Bytes[patternMatch.Index + 1] = newData[1];
        Bytes[patternMatch.Index + 2] = newData[2];
        Bytes[patternMatch.Index + 3] = newData[3];
      }
    }

  }
}
