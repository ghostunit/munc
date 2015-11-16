using Mp4HeaderFix;

namespace Mp4HeaderFixTests.Samples
{
  class SampleBinaryFile : BinaryFile
  {
    internal SampleBinaryFile(string filename, byte[] fileAsBytes, FileResult fileResult = FileResult.Success)
    {
      this.filename = filename;
      this.fileAsBytes = fileAsBytes;
      this.fileResult = fileResult;
    }
  }
}
