using System;
namespace Mp4HeaderFix
{
  internal static class ExtensionMethods
  {

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
