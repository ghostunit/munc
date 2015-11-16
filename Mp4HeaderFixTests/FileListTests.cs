using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;
using Mp4HeaderFixTests.Samples;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class FileListTests
  {
    [TestMethod]
    public void EnsureFileListExists()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJob.Run();

      int filesAccountedFor = 0;
      if (Directory.Exists(SampleFilenames.TempDirectory))
      {
        for (int i = 1; i <= 15; i++)
        {
          string f = SampleFilenames.TempDirectory + "SampleFile_00" + i.ToString("D2") + ".mp4";
          if (File.Exists(f))
          {
            filesAccountedFor++;
          }
        }
      }

      Assert.AreEqual(15, filesAccountedFor);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void Length_ShouldMatchNumberOfFiles_WhenGivenFolder()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJob.Run();

      Assert.AreEqual(15, new FileList(SampleFilenames.TempDirectory).Length);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void Length_ShouldBeOne_WhenGivenFile()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJob.Run();

      Assert.AreEqual(1, new FileList(SampleFilenames.FileThatExistsInTempDirectory).Length);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void Result_ShouldBeSuccess_OnLoadFolder()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJob.Run();

      Assert.AreEqual(FileResult.Success, new FileList(SampleFilenames.TempDirectory).Result);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void Result_ShouldBeSuccess_OnLoadFile()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJob.Run();

      Assert.AreEqual(FileResult.Success, new FileList(SampleFilenames.FileThatExistsInTempDirectory).Result);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }

    [TestMethod]
    public void Result_ShouldBeIllegal_WhenGivenIllegalCharcters()
    {
      Mp4RepairJob mp4RepairJob = SampleMp4RepairJobs.AllFilesSuccess();
      mp4RepairJob.Run();

      Assert.AreEqual(FileResult.IllegalFilename, new FileList(SampleFilenames.TempDirectoryWithIllegalCharacters).Result);

      SampleMp4RepairJobs.DeleteTempDirectory();
    }
  }
}
