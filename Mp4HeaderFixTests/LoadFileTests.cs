using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;
using Mp4HeaderFixTests.Samples;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class LoadFileTests
  {
    /*
    SampleFilenames files = new SampleFilenames();

    [TestMethod]
    public void Result_ShouldBeLoaded_WhenByteArrayIsCreatedFromFilename()
    {
      Assert.AreEqual(ReadFileResult.Success, new LoadFile(files.FileThatExists).Result);
    }

    [TestMethod]
    public void Result_ShouldBeFileNotFound_WhenFileDoesNotExist()
    {
      Assert.AreEqual(ReadFileResult.PathNotFound, new LoadFile(files.FileThatDoesNotExist).Result);
    }

    [TestMethod]
    public void Result_ShouldBeIllegalFilename_WhenFilenameIsEmpty()
    {
      Assert.AreEqual(ReadFileResult.IllegalFilename, new LoadFile(String.Empty).Result);
    }

    [TestMethod]
    public void Result_ShouldBeIllegalFilename_WhenFilenameContainsIllegalChars()
    {
      Assert.AreEqual(ReadFileResult.IllegalFilename, new LoadFile(files.FileWithIllegalCharacters).Result);
    }

    [TestMethod]
    public void Bytes_ShouldBeLongerThanZero_WhenFileIsLoaded()
    {
      Assert.IsTrue(new LoadFile(files.FileThatExists).Bytes.Length > 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenFileDoesNotExist()
    {
      Assert.IsTrue(new LoadFile(files.FileThatDoesNotExist).Bytes.Length == 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenFilenameIsEmpty()
    {
      Assert.IsTrue(new LoadFile(String.Empty).Bytes.Length == 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenFilenameContainsIllegalChars()
    {
      Assert.IsTrue(new LoadFile(files.FileThatDoesNotExist).Bytes.Length == 0);
    }
    */
  }
}
