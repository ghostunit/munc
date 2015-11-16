using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;
using Mp4HeaderFixTests.Samples;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class PatternMatchTests
  {
    [TestMethod]
    public void Success_ShouldReturnTrue_WhenPatternIsFound()
    {
      Assert.IsTrue(new PatternMatch(SampleByteArrays.PatternThatExists, SampleByteArrays.ArrayToSearch).Success);
    }

    [TestMethod]
    public void Success_ShouldReturnFalse_WhenPatternIsNotFound()
    {
      Assert.IsFalse(new PatternMatch(SampleByteArrays.PatternThatDoesNotExist, SampleByteArrays.ArrayToSearch).Success);
    }

    [TestMethod]
    public void Index_ShouldReturnCorrectIndex_WhenByteArrayIsFound()
    {
      Assert.AreEqual(7, new PatternMatch(SampleByteArrays.PatternThatExists, SampleByteArrays.ArrayToSearch).Index);
    }

    [TestMethod]
    public void Index_ShouldReturnZero_WhenByteArrayIsNotFound()
    {
      Assert.AreEqual(0, new PatternMatch(SampleByteArrays.PatternThatDoesNotExist, SampleByteArrays.ArrayToSearch).Index);
    }
  }
}
