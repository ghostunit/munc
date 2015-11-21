using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4UnCropper;
using Mp4UnCropperTests.Samples;

namespace Mp4UnCropperTests
{
  [TestClass]
  public class Mp4RepairJobTests
  {
    [TestMethod]
    public void LoadFailures_ShouldBeEmpty_WhenAllFilesAreLoaded()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJob.Run();
      List<JobResult> loadFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Load);

      Assert.AreEqual(0, loadFailures.Count);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void JobResults_ShouldBeEmpty_WhenNoFilesExist()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.NoFilesExist();
      mp4RepairJob.Run();

      Assert.AreEqual(0, mp4RepairJob.Results.Count);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void WriteFailures_ShouldBeEmpty_WhenAllFilesAreWritten()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJob.Run();
      List<JobResult> writeFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Write);

      Assert.AreEqual(15, mp4RepairJob.Results.Count);
      Assert.AreEqual(0, writeFailures.Count);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void RunResult_All15FilesMustExist_WhenGivenProperFiles()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJob.Run();
      Assert.AreEqual(15, mp4RepairJob.Results.Count);

      for (int i = 1; i <= 15; i++)
      {
        string originalFilename = SampleFilenames.TempDirectory + "SampleFile_00" + i.ToString("D2") + ".mp4";
        string newFilename = SampleFilenames.TempDestinationDirectory + "SampleFile_00" + i.ToString("D2") + ".mp4";
        JobResult jobResult = mp4RepairJob.Results.Find(job => job.JobID == (i - 1));

        Assert.AreEqual(originalFilename, jobResult.OriginalFilename);
        Assert.AreEqual(newFilename, jobResult.NewFilename);
        Assert.IsTrue(File.Exists(originalFilename));
        Assert.IsTrue(File.Exists(newFilename));
      }

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void RunResult_FailureCountsAreCorrect_WhenOneFileDoesntContainOldDimensions()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.OneFileWithoutOldDimensions();
      mp4RepairJob.Run();

      List<JobResult> successes = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.None);
      List<JobResult> loadFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Load);
      List<JobResult> modifyFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Modify);
      List<JobResult> writeFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Write);

      Assert.AreEqual(15, mp4RepairJob.Results.Count);
      Assert.AreEqual(14, successes.Count);
      Assert.AreEqual(0, loadFailures.Count);
      Assert.AreEqual(1, modifyFailures.Count);
      Assert.AreEqual(0, writeFailures.Count);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void RunResult_FailureCountsAreCorrect_WhenOneFileHasIllegalCharacters()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.SourceContainsIllegalFilenames();
      mp4RepairJob.Run();

      List<JobResult> successes = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.None);
      List<JobResult> loadFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Load);
      List<JobResult> modifyFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Modify);
      List<JobResult> writeFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Write);

      Assert.AreEqual(1, mp4RepairJob.Results.Count);
      Assert.AreEqual(0, successes.Count);
      Assert.AreEqual(1, loadFailures.Count);
      Assert.AreEqual(0, modifyFailures.Count);
      Assert.AreEqual(0, writeFailures.Count);
    }

    [TestMethod]
    public void RunResult_FailureCountsAreCorrect_WhenSomeFilesAreNotMp4()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.SomeNonMp4Files();
      mp4RepairJob.Run();

      List<JobResult> successes = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.None);
      List<JobResult> loadFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Load);
      List<JobResult> modifyFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Modify);
      List<JobResult> writeFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Write);

      Assert.AreEqual(15, mp4RepairJob.Results.Count);
      Assert.AreEqual(15, successes.Count);
      Assert.AreEqual(0, loadFailures.Count);
      Assert.AreEqual(0, modifyFailures.Count);
      Assert.AreEqual(0, writeFailures.Count);
    }

    [TestMethod]
    public void RunResult_FailureCountsAreCorrect_DestinationHasIllegalFilenames()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.DestinationHasIllegalFilenames();
      mp4RepairJob.Run();

      List<JobResult> successes = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.None);
      List<JobResult> loadFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Load);
      List<JobResult> modifyFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Modify);
      List<JobResult> writeFailures = mp4RepairJob.Results.FindAll(job => job.FailurePoint == FailureType.Write);

      Assert.AreEqual(15, mp4RepairJob.Results.Count);
      Assert.AreEqual(0, successes.Count);
      Assert.AreEqual(0, loadFailures.Count);
      Assert.AreEqual(0, modifyFailures.Count);
      Assert.AreEqual(15, writeFailures.Count);
    }

    [TestMethod]
    public void RunResult_VerifyBytesHavebeenChanged_InFilesThatContainThePattern()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.OneFileWithoutOldDimensions();
      mp4RepairJob.Run();

      List<JobResult> successes = mp4RepairJob.Results.FindAll(job => job.Passed == true);

      Assert.AreEqual(15, mp4RepairJob.Results.Count);
      Assert.AreEqual(14, successes.Count);

      foreach (JobResult result in successes)
      {
        LoadFile loadFile = new LoadFile(result.NewFilename);
        PatternMatch match = new PatternMatch(SampleByteArrays.Dimensions640x480, loadFile.Bytes);
        Assert.IsTrue(match.Success);
      }

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void RunResult_VerifyFilesWereNotWritten_WhenFilesDoNotContainThePattern()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.OneFileWithoutOldDimensions();
      mp4RepairJob.Run();

      List<JobResult> modifyFailures = mp4RepairJob.Results.FindAll(job => job.FailureResult == FileResult.PatternNotFound);

      Assert.AreEqual(15, mp4RepairJob.Results.Count);
      Assert.AreEqual(1, modifyFailures.Count);

      foreach (JobResult result in modifyFailures)
      {
        Assert.IsFalse(File.Exists(result.NewFilename));
      }

      SampleMp4RepairJobs.DeleteTempDirectory();
    }
  }
}
