using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;
using Mp4HeaderFixTests.Samples;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class PatternMatchTests
  {
    SampleByteArrays bytes = new SampleByteArrays();

    [TestMethod]
    public void Success_ShouldReturnTrue_WhenPatternIsFound()
    {
      Assert.IsTrue(new PatternMatch(bytes.PatternThatExists, bytes.ArrayToSearch).Success);
    }

    [TestMethod]
    public void Success_ShouldReturnFalse_WhenPatternIsNotFound()
    {
      Assert.IsFalse(new PatternMatch(bytes.PatternThatDoesNotExist, bytes.ArrayToSearch).Success);
    }

    [TestMethod]
    public void Index_ShouldReturnCorrectIndex_WhenByteArrayIsFound()
    {
      Assert.AreEqual(7, new PatternMatch(bytes.PatternThatExists, bytes.ArrayToSearch).Index);
    }

    [TestMethod]
    public void Index_ShouldReturnZero_WhenByteArrayIsNotFound()
    {
      Assert.AreEqual(0, new PatternMatch(bytes.PatternThatDoesNotExist, bytes.ArrayToSearch).Index);
    }

  }
}
