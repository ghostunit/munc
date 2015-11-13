namespace Mp4HeaderFix
{
  public static class ByteExtensions
  {
    public static byte[] ReplaceBytes(this byte[] originalFile, byte[] oldDimensions, byte[] newData)
    {
      byte[] result = originalFile;
      PatternMatch patternMatch = new PatternMatch(oldDimensions, originalFile);
      if (patternMatch.Success)
      {
        result[patternMatch.Index] = newData[0];
        result[patternMatch.Index + 1] = newData[1];
        result[patternMatch.Index + 2] = newData[2];
        result[patternMatch.Index + 3] = newData[3];
      }
      return result;
    }
  }
}
