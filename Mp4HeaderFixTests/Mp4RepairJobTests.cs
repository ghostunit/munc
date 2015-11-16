using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;
using Mp4HeaderFixTests.Samples;
using System.IO;
using System;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class Mp4RepairJobTests
  {
    [TestMethod]
    public void LoadFailures_ShouldBeEmpty_WhenAllFilesAreLoaded()
    {
      Mp4RepairJob mp4RepairJobSuccess = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJobSuccess.Run();
      SampleMp4RepairJobs.DeleteTempDirectory();
      Assert.AreEqual(0, mp4RepairJobSuccess.LoadFailures.Count);
    }

    [TestMethod]
    public void WriteFailures_ShouldBeEmpty_WhenAllFilesAreWritten()
    {
      Mp4RepairJob mp4RepairJobSuccess = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJobSuccess.Run();
      SampleMp4RepairJobs.DeleteTempDirectory();
      Assert.AreEqual(0, mp4RepairJobSuccess.WriteFailures.Count);
    }

    [TestMethod]
    public void RunResult_All15FilesMustExist_WhenGivenProperFiles()
    {
      Mp4RepairJob job = SampleMp4RepairJobs.AllFilesSuccess();
      Dictionary<string, string> results = job.Run();
      Assert.AreEqual(15, results.Count);

      for (int i = 1; i <= 15; i++)
      {
        string originalFilename = SampleFilenames.TempDirectory + "SampleFile_00" + i + ".bin";
        string newFilename = SampleFilenames.TempDestinationDirectory + "SampleFile_00" + i + ".bin";
        string dictionaryValue = String.Empty;

        Assert.IsTrue(results.TryGetValue(originalFilename, out dictionaryValue));
        Assert.AreEqual(newFilename, dictionaryValue);
        Assert.IsTrue(File.Exists(originalFilename));
        Assert.IsTrue(File.Exists(newFilename));
        Assert.IsTrue(File.Exists(dictionaryValue));
      }

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void RunResult_All15FilesMustExist_WhenOneFileDoesntContainOldDimensions()
    {
      Mp4RepairJob job = SampleMp4RepairJobs.OneFileWithoutOldDimensions();
      Dictionary<string, string> results = job.Run();

      Assert.AreEqual(0, job.LoadFailures);
      Assert.AreEqual(1, job.WriteFailures);

      for (int i = 1; i <= 15; i++)
      {
        string originalFilename = SampleFilenames.TempDirectory + "SampleFile_00" + i + ".bin";
        string newFilename = SampleFilenames.TempDestinationDirectory + "SampleFile_00" + i + ".bin";
        string dictionaryValue = String.Empty;

        Assert.IsTrue(results.TryGetValue(originalFilename, out dictionaryValue));
        Assert.AreEqual(newFilename, dictionaryValue);
        Assert.IsTrue(File.Exists(originalFilename));
        Assert.IsTrue(File.Exists(newFilename));
        Assert.IsTrue(File.Exists(dictionaryValue));
      }

      SampleMp4RepairJobs.DeleteTempDirectory();
    }


    /*
     * check the loadfile results
     * check the writefile results
     * check the output of the actual bytes for
     * -- success
     * -- note found
     * -- failures
     * see what happens with bad paths for read or write
     * 
     * 
    */
  }
}
