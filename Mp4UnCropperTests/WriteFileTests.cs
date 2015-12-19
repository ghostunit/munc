using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4UnCropper;
using Mp4UnCropperTests.Samples;

namespace Mp4UnCropperTests
{
  [TestClass]
  public class WriteFileTests
  {
    [TestMethod]
    public void MakeSureTestVideoExists()
    {
      new WriteFile(new SampleBinaryFile(SampleFilenames.FileThatExists, SampleByteArrays.ArrayToSearch));
      Assert.IsTrue(System.IO.File.Exists(SampleFilenames.FileThatExists));
      System.IO.File.Delete(SampleFilenames.FileThatExists);
    }

    [TestMethod]
    public void Bytes_ShouldBeLongerThanZero_WhenGivenValidArray()
    {
      SampleBinaryFile sampleBinaryFile = new SampleBinaryFile(SampleFilenames.FileThatExists, SampleByteArrays.ArrayToSearch);
      Assert.IsTrue(new WriteFile(sampleBinaryFile).Bytes.Length > 0);
      System.IO.File.Delete(SampleFilenames.FileThatExists);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenGivenEmptyArray()
    {
      SampleBinaryFile sampleBinaryFile = new SampleBinaryFile(SampleFilenames.FileThatExists, SampleByteArrays.EmptyArray);
      Assert.IsTrue(new WriteFile(sampleBinaryFile).Bytes.Length == 0);
    }

    [TestMethod]
    public void Result_ShouldBeSaved_WhenGivenProperData()
    {
      SampleBinaryFile sampleBinaryFile = new SampleBinaryFile(SampleFilenames.TemporaryFileToWrite, SampleByteArrays.ArrayToSearch);
      Assert.IsTrue(new WriteFile(sampleBinaryFile).Result == FileResult.Success);
      System.IO.File.Delete(SampleFilenames.TemporaryFileToWrite);
    }

    [TestMethod]
    public void Result_ShouldBeNoData_WhenGivenEmptyByteArray()
    {
      SampleBinaryFile sampleBinaryFile = new SampleBinaryFile(SampleFilenames.TemporaryFileToWrite, SampleByteArrays.EmptyArray);
      Assert.AreEqual(FileResult.NoDataToSave, new WriteFile(sampleBinaryFile).Result);
    }

    [TestMethod]
    public void Result_ShouldBeIllegalFilename_WhenGivenBadName()
    {
      SampleBinaryFile sampleBinaryFile = new SampleBinaryFile(SampleFilenames.FileWithIllegalCharacters, SampleByteArrays.ArrayToSearch);
      Assert.AreEqual(FileResult.IllegalFilename, new WriteFile(sampleBinaryFile).Result);
    }

    [TestMethod]
    public void Result_ShouldBeSaved_WhenOverwriting()
    {
      SampleBinaryFile sampleBinaryFile1 = new SampleBinaryFile(SampleFilenames.TemporaryFileToWrite, SampleByteArrays.ArrayToSearch);
      SampleBinaryFile sampleBinaryFile2 = new SampleBinaryFile(SampleFilenames.TemporaryFileToWrite, SampleByteArrays.PatternThatExists);
      WriteFile writeFile1 = new WriteFile(sampleBinaryFile1);
      WriteFile writeFile = new WriteFile(sampleBinaryFile2);
      Assert.AreEqual(FileResult.Success, writeFile.Result);
      System.IO.File.Delete(SampleFilenames.TemporaryFileToWrite);
    }
  }
}
