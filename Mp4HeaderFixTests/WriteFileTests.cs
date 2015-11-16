using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;
using Mp4HeaderFixTests.Samples;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class WriteFileTests
  {
    /*
    SampleFilenames files = new SampleFilenames();
    SampleByteArrays bytes = new SampleByteArrays();

    [TestMethod]
    public void MakeSureTestVideoExists()
    {
      Assert.IsTrue(System.IO.File.Exists(files.FileThatExists));
    }

    [TestMethod]
    public void Bytes_ShouldBeLongerThanZero_WhenGivenValidArray()
    {
      Assert.IsTrue(new WriteFile(new SampleByteArrays().ArrayToSearch, files.FileThatExists).Bytes.Length > 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenGivenEmptyArray()
    {
      Assert.IsTrue(new WriteFile(bytes.EmptyArray, files.FileThatExists).Bytes.Length == 0);
    }

    [TestMethod]
    public void Result_ShouldBeSaved_WhenGivenProperData()
    {
      WriteFile writeFile = new WriteFile(bytes.ArrayToSearch, files.TemporaryFileToWrite);
      Assert.IsTrue(writeFile.Result == WriteFileResult.Success);
      System.IO.File.Delete(files.TemporaryFileToWrite);
    }

    [TestMethod]
    public void Result_ShouldBeNoData_WhenGivenEmptyByteArray()
    {
      WriteFile writeFile = new WriteFile(bytes.EmptyArray, files.TemporaryFileToWrite);
      Assert.AreEqual(WriteFileResult.NoDataToSave, writeFile.Result);
    }

    [TestMethod]
    public void Result_ShouldBeIllegalFilename_WhenGivenBadName()
    {
      WriteFile writeFile = new WriteFile(bytes.ArrayToSearch, files.FileWithIllegalCharacters);
      Assert.AreEqual(WriteFileResult.IllegalFilename, writeFile.Result);
    }

    [TestMethod]
    public void Result_ShouldBeSaved_WhenOverwriting()
    {
      WriteFile writeFile1 = new WriteFile(bytes.ArrayToSearch, files.TemporaryFileToWrite);
      WriteFile writeFile = new WriteFile(bytes.PatternThatExists, files.TemporaryFileToWrite);
      Assert.AreEqual(WriteFileResult.Success, writeFile.Result);
      System.IO.File.Delete(files.TemporaryFileToWrite);
    }
    */
  }
}
