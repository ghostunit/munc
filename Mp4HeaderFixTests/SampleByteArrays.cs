namespace Mp4HeaderFixTests
{
  class SampleByteArrays
  {
    public byte[] ArrayToSearch = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
    public byte[] PatternThatExists = new byte[] { 7, 8, 9, 10 };
    public byte[] PatternThatDoesNotExist = new byte[] { 74, 38, 95, 200 };
  }
}
