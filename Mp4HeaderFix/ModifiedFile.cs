using System;
namespace Mp4HeaderFix
{
  internal class ModifiedFile : IBinaryFile
  {
    private byte[] originalFile;
    private byte[] oldData;
    private byte[] newData;
    private ModifyFileResult modifyFileResult;

    public byte[] Bytes
    {
      get
      {
        return ReplaceBytes();
      }
    }
    
    internal ModifiedFile(byte[] originalFile, byte[] oldData, byte[] newData)
    {
      this.originalFile = originalFile;
      this.oldData = oldData;
      this.newData = newData;
      this.modifyFileResult = ModifyFileResult.Undefined;
    }

    internal byte[] ReplaceBytes()
    {
      byte[] result = this.originalFile;

      if (result == null || result.Length == 0)
      {
        this.modifyFileResult = ModifyFileResult.NoFileToModify;
      }

      PatternMatch patternMatch = new PatternMatch(this.oldData, result);
      if (!patternMatch.Success)
      {
        this.modifyFileResult = ModifyFileResult.PatternNotFound;
      }
      else
      {
        this.modifyFileResult = ModifyFileResult.Success;
        result[patternMatch.Index] = this.newData[0];
        result[patternMatch.Index + 1] = this.newData[1];
        result[patternMatch.Index + 2] = this.newData[2];
        result[patternMatch.Index + 3] = this.newData[3];
      }

      return result;
    }

  }
}
