using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class WriteFileTests
  {
    [TestMethod]
    public void Bytes_ShouldBeLongerThanZero_WhenGivenValidArray()
    {
      Assert.IsTrue(new WriteFile(new SampleByteArrays().ArrayToSearch, "filename").Bytes.Length > 0);
    }

    [TestMethod]
    public void Bytes_ShouldBeZero_WhenGivenEmptyArray()
    {
      Assert.IsTrue(new WriteFile(new byte[0], "filename").Bytes.Length == 0);
    }

    //TODO: Test the file IO



  }
}
