using System;
namespace Mp4UnCropper
{
  /// <summary>
  /// Helper methods for workign with the MP4 Header Fix class library
  /// </summary>
  public static class ExtensionMethods
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

    /// <summary>
    /// Converts a string to UInt16. Expects a prevalidated input and returns zero on failure.
    /// </summary>
    /// <param name="stringToConvert">The pre-validated string to be converted to UInt16</param>
    /// <returns>Returns an unsigned, 2 byte integer</returns>
    public static UInt16 ToUInt16(this string stringToConvert)
    {
      UInt16 result = 0;
      UInt16.TryParse(stringToConvert, out result);
      return result;
    }

  }
}
