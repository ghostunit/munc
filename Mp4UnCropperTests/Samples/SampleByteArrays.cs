namespace Mp4UnCropperTests.Samples
{
  public static class SampleByteArrays
  {
    public static byte[] ArrayToSearch = new byte[] { 1, 2, 3, 4, 5, 6, 7, 0x01, 0x40, 0x00, 0xF0, 8, 9, 10, 11, 12, 13, 14, 15 };
    public static byte[] ArrayToSearchWithoutPattern = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    public static byte[] PatternThatExists = new byte[] { 0x01, 0x40, 0x00, 0xF0 };
    public static byte[] PatternThatDoesNotExist = new byte[] { 74, 38, 95, 200 };
    public static byte[] EmptyArray = new byte[0];
    public static byte[] Dimensions320x240 = new byte[] { 0x01, 0x40, 0x00, 0xF0 };
    public static byte[] Dimensions640x480 = new byte[] { 0x02, 0x80, 0x01, 0xE0 };
  }
}
