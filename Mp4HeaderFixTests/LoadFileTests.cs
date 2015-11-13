using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class LoadFileTests
  {
    SampleFilenames f = new SampleFilenames();

    [TestMethod]
    public void Result_ShouldBeLoaded_WhenByteArrayIsCreatedFromFilename()
    {
      Assert.AreEqual(FileLoadResult.Loaded, new LoadFile(f.FileThatExists).Result);
    }

    [TestMethod]
    public void Result_ShouldBeFileNotFound_WhenFileDoesNotExist()
    {
      Assert.AreEqual(FileLoadResult.FileNotFound, new LoadFile(f.FileThatDoesNotExist).Result);
    }

    [TestMethod]
    public void Result_ShouldBeIllegalFilename_WhenFilenameIsEmpty()
    {
      Assert.AreEqual(FileLoadResult.IllegalFilename, new LoadFile(String.Empty).Result);
    }

    [TestMethod]
    public void Result_ShouldBeIllegalFilename_WhenFilenameContainsIllegalChars()
    {
      Assert.AreEqual(FileLoadResult.IllegalFilename, new LoadFile(f.FileWithIllegalCharacters).Result);
    }

    [TestMethod]
    public void Bytes_ShouldBeLongerThanZero_WhenFileIsLoaded()
    {
      Assert.IsTrue(new LoadFile(f.FileThatExists).Bytes.Length > 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenFileDoesNotExist()
    {
      Assert.IsTrue(new LoadFile(f.FileThatDoesNotExist).Bytes.Length == 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenFilenameIsEmpty()
    {
      Assert.IsTrue(new LoadFile(String.Empty).Bytes.Length == 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenFilenameContainsIllegalChars()
    {
      Assert.IsTrue(new LoadFile(f.FileThatDoesNotExist).Bytes.Length == 0);
    }

  }
}
