using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;
using Mp4HeaderFixTests.Samples;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class Mp4RepairJobTests
  {
    SampleFilenames f = new SampleFilenames();
    SampleByteArrays b = new SampleByteArrays();

    [TestMethod]
    public void ThisReallyDoesntTestAnything()
    {
      SampleFileList l = new SampleFileList();

      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);
      FileSaveRule fileSaveRule = new FileSaveRule("", "", f.TempDirectory + @"Converted\");

      Assert.IsTrue(new Mp4RepairJob(f.TempDirectory, oldDimensions, newDimensions, fileSaveRule).Run());
    }
  }
}
