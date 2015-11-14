namespace Mp4HeaderFixTests.Samples
{
  class SampleByteArrays
  {
    public byte[] ArrayToSearch = new byte[] { 1, 2, 3, 4, 5, 6, 7, 0x01, 0x40, 0x00, 0xF0, 8, 9, 10, 11, 12, 13, 14, 15 };
    public byte[] PatternThatExists = new byte[] { 0x01, 0x40, 0x00, 0xF0 };
    public byte[] PatternThatDoesNotExist = new byte[] { 74, 38, 95, 200 };
    public byte[] EmptyArray = new byte[0];
    public byte[] Dimensions320x240 = new byte[] { 0x01, 0x40, 0x00, 0xF0 };
    public byte[] Dimensions640x480 = new byte[] { 0x02, 0x80, 0x01, 0xE0 };
  }
}
