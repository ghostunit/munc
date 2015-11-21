using Mp4UnCropper;

namespace Mp4UnCropperTests.Samples
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
