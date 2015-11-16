using System;
namespace Mp4HeaderFix
{
  internal class ModifiedFile
  {
    private byte[] originalFile;
    private byte[] oldData;
    private byte[] newData;
    private ModifyFileResult modifyFileResult;

    internal ModifiedFile(byte[] originalFile, byte[] oldData, byte[] newData)
    {
      this.originalFile = originalFile;
      this.oldData = oldData;
      this.newData = newData;
      this.modifyFileResult = ModifyFileResult.Undefined;
    }

    internal byte[] ReplaceBytes(byte[] originalFile, byte[] oldDimensions, byte[] newData)
    {
      byte[] result = originalFile;

      if (originalFile == null || originalFile.Length == 0)
      {
        this.modifyFileResult = ModifyFileResult.NoFileToModify;
      }

      PatternMatch patternMatch = new PatternMatch(oldDimensions, originalFile);
      if (!patternMatch.Success)
      {
        this.modifyFileResult = ModifyFileResult.PatternNotFound;
      }
      else
      {
        this.modifyFileResult = ModifyFileResult.Success;
        result[patternMatch.Index] = newData[0];
        result[patternMatch.Index + 1] = newData[1];
        result[patternMatch.Index + 2] = newData[2];
        result[patternMatch.Index + 3] = newData[3];
      }

      return result;
    }

  }
}
