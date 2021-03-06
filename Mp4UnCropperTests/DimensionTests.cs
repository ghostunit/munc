﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4UnCropper;
using Mp4UnCropperTests.Samples;

namespace Mp4UnCropperTests
{
  [TestClass]
  public class DimensionTests
  {
    [TestMethod]
    public void AsBytes_ShouldReturn014000F0_For320x240()
    {
      for (int i = 0; i < 4; i++)
      {
        Assert.AreEqual(SampleByteArrays.Dimensions320x240[i], new Dimension(320, 240).AsBytes[i]);
      }
    }
    
    [TestMethod]
    public void AsBytes_ShouldReturn028001E0_For640x480()
    {
      for (int i = 0; i < 4; i++)
      {
        Assert.AreEqual(SampleByteArrays.Dimensions640x480[i], new Dimension(640, 480).AsBytes[i]);
      }
    }

  }
}
