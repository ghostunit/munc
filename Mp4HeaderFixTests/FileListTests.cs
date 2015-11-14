using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mp4HeaderFix;
using Mp4HeaderFixTests.Samples;
using System.IO;

namespace Mp4HeaderFixTests
{
  [TestClass]
  public class FileListTests
  {
    SampleFilenames files = new SampleFilenames();
    SampleFileList fileList = new SampleFileList();

    [TestMethod]
    public void EnsureFileListExists()
    {
      int filesAccountedFor = 0;
      if (Directory.Exists(files.TempDirectory))
      {
        for (int i = 1; i <= 15; i++)
        {
          string f = files.TempDirectory + "SampleFile_00" + i + ".bin";
          if (File.Exists(f))
          {
            filesAccountedFor++;
          }
        }
      }
      Assert.AreEqual(15, filesAccountedFor);
    }

    [TestMethod]
    public void Length_ShouldMatchNumberOfFiles_WhenGivenFolder()
    {
      Assert.AreEqual(15, new FileList(files.TempDirectory).Length);
    }

    [TestMethod]
    public void Length_ShouldBeOne_WhenGivenFile()
    {
      Assert.AreEqual(1, new FileList(files.FileThatExistsInTempDirectory).Length);
    }

    [TestMethod]
    public void Result_ShouldBeSuccess_OnLoadFolder()
    {
      Assert.AreEqual(ReadFileResult.Success, new FileList(files.TempDirectory).Result);
    }

    [TestMethod]
    public void Result_ShouldBeSuccess_OnLoadFile()
    {
      Assert.AreEqual(ReadFileResult.Success, new FileList(files.FileThatExistsInTempDirectory).Result);
    }

    [TestMethod]
    public void Result_ShouldBeIllegal_WhenGivenIllegalCharcters()
    {
      Assert.AreEqual(ReadFileResult.IllegalFilename, new FileList(files.TempDirectoryWithIllegalCharacters).Result);
    }

  }
}
