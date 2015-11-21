using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4UnCropper;
using Mp4UnCropperTests.Samples;

namespace Mp4UnCropperTests
{
  [TestClass]
  public class LoadFileTests
  {
    [TestMethod]
    public void Result_ShouldBeLoaded_WhenByteArrayIsCreatedFromFilename()
    {
      Assert.AreEqual(FileResult.Success, new LoadFile(SampleFilenames.FileThatExists).Result);
    }

    [TestMethod]
    public void Result_ShouldBeFileNotFound_WhenFileDoesNotExist()
    {
      Assert.AreEqual(FileResult.PathNotFound, new LoadFile(SampleFilenames.FileThatDoesNotExist).Result);
    }

    [TestMethod]
    public void Result_ShouldBeIllegalFilename_WhenFilenameIsEmpty()
    {
      Assert.AreEqual(FileResult.IllegalFilename, new LoadFile(string.Empty).Result);
    }

    [TestMethod]
    public void Result_ShouldBeIllegalFilename_WhenFilenameContainsIllegalChars()
    {
      Assert.AreEqual(FileResult.IllegalFilename, new LoadFile(SampleFilenames.FileWithIllegalCharacters).Result);
    }

    [TestMethod]
    public void Bytes_ShouldBeLongerThanZero_WhenFileIsLoaded()
    {
      Assert.IsTrue(new LoadFile(SampleFilenames.FileThatExists).Bytes.Length > 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenFileDoesNotExist()
    {
      Assert.IsTrue(new LoadFile(SampleFilenames.FileThatDoesNotExist).Bytes.Length == 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenFilenameIsEmpty()
    {
      Assert.IsTrue(new LoadFile(string.Empty).Bytes.Length == 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenFilenameContainsIllegalChars()
    {
      Assert.IsTrue(new LoadFile(SampleFilenames.FileThatDoesNotExist).Bytes.Length == 0);
    }
  }
}
