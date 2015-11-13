using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class PatternMatchTests
  {
    SampleByteArrays s = new SampleByteArrays();

    [TestMethod]
    public void Success_ShouldReturnTrue_WhenPatternIsFound()
    {
      Assert.IsTrue(new PatternMatch(s.PatternThatExists, s.ArrayToSearch).Success);
    }

    [TestMethod]
    public void Success_ShouldReturnFalse_WhenPatternIsNotFound()
    {
      Assert.IsFalse(new PatternMatch(s.PatternThatDoesNotExist, s.ArrayToSearch).Success);
    }

    [TestMethod]
    public void Index_ShouldReturnCorrectIndex_WhenByteArrayIsFound()
    {
      Assert.AreEqual(6, new PatternMatch(s.PatternThatExists, s.ArrayToSearch).Index);
    }

    [TestMethod]
    public void Index_ShouldReturnZero_WhenByteArrayIsNotFound()
    {
      Assert.AreEqual(0, new PatternMatch(s.PatternThatDoesNotExist, s.ArrayToSearch).Index);
    }

  }
}
