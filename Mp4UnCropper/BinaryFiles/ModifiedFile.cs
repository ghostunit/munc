namespace Mp4UnCropper
{
  internal class ModifiedFile : BinaryFile
  {
    private byte[] originalFile;
    private byte[] oldData;
    private byte[] newData;

    internal ModifiedFile(byte[] originalFile, byte[] oldData, byte[] newData, string destinationFilename)
    {
      this.originalFile = originalFile;
      this.oldData = oldData;
      this.newData = newData;
      this.filename = destinationFilename;
      this.fileResult = FileResult.Undefined;
      ReplaceBytes();
    }

    private void ReplaceBytes()
    {
      this.fileAsBytes = this.originalFile;

      if (this.fileAsBytes == null || this.fileAsBytes.Length == 0)
      {
        this.fileAsBytes = new byte[0];
        this.fileResult = FileResult.NoFileToModify;
      }

      PatternMatch patternMatch = new PatternMatch(this.oldData, this.fileAsBytes);
      if (!patternMatch.Success)
      {
        this.fileAsBytes = new byte[0];
        this.fileResult = FileResult.PatternNotFound;
      }
      else
      {
        this.fileResult = FileResult.Success;
        this.fileAsBytes[patternMatch.Index] = this.newData[0];
        this.fileAsBytes[patternMatch.Index + 1] = this.newData[1];
        this.fileAsBytes[patternMatch.Index + 2] = this.newData[2];
        this.fileAsBytes[patternMatch.Index + 3] = this.newData[3];
      }
    }

  }
}
