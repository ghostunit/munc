using System;
namespace Mp4HeaderFix
{
  internal static class ExtensionMethods
  {
    //internal static byte[] ReplaceBytes(this byte[] originalFile, byte[] oldDimensions, byte[] newData)
    //{
    //  byte[] result = originalFile;
    //  PatternMatch patternMatch = new PatternMatch(oldDimensions, originalFile);
    //  if (patternMatch.Success)
    //  {
    //    result[patternMatch.Index] = newData[0];
    //    result[patternMatch.Index + 1] = newData[1];
    //    result[patternMatch.Index + 2] = newData[2];
    //    result[patternMatch.Index + 3] = newData[3];
    //  }
    //  return result;
    //}

    internal static byte[] GetBytes(this UInt16 intToConvert)
    {
      byte[] result;
      result = BitConverter.GetBytes(intToConvert);
      if (BitConverter.IsLittleEndian)
      {
        Array.Reverse(result);
      }
      return result;
    }

  }
}
