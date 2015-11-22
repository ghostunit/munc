using Mp4UnCropper;

namespace Mp4UnCropperTests.Samples
{
  internal class SampleBinaryFile : BinaryFile
  {
    internal SampleBinaryFile(string filename, byte[] fileAsBytes, FileResult fileResult = FileResult.Success)
    {
      Path = filename;
      Bytes = fileAsBytes;
      Result = fileResult;
    }
  }
}
