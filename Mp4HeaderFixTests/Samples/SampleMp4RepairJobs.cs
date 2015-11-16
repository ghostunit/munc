using Mp4HeaderFix;
using System.IO;

namespace Mp4HeaderFixTests.Samples
{
  public static class SampleMp4RepairJobs
  {

    public static Mp4RepairJob AllFilesSuccess()
    {
      CreateTempDirectory();
      CreateSampleFilesWithStandardByteArray();

      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);
      FileSaveRule fileSaveRule = new FileSaveRule("", "", SampleFilenames.TempDestinationDirectory);

      return new Mp4RepairJob(SampleFilenames.TempDirectory, oldDimensions, newDimensions, fileSaveRule);
    }

    public static Mp4RepairJob OneFileWithoutOldDimensions()
    {
      CreateTempDirectory();
      CreateSampleFilesWithStandardByteArray();
      WriteFile overwriteOneFile = new WriteFile(SampleByteArrays.ArrayToSearchWithoutPattern, SampleFilenames.TempDirectory + "SampleFile_007.bin");

      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);
      FileSaveRule fileSaveRule = new FileSaveRule("", "", SampleFilenames.TempDestinationDirectory);

      return new Mp4RepairJob(SampleFilenames.TempDirectory, oldDimensions, newDimensions, fileSaveRule);
    }

    public static void DeleteTempDirectory()
    {
      Directory.Delete(SampleFilenames.TempDirectory, true);
    }

    private static void CreateSampleFilesWithStandardByteArray()
    {
      for (int i = 1; i <= 15; i++)
      {
        byte[] b = SampleByteArrays.ArrayToSearch;
        WriteFile f = new WriteFile(b, SampleFilenames.TempDirectory + "SampleFile_00" + i + ".bin");
      }
    }

    private static void CreateTempDirectory()
    {
      if (Directory.Exists(SampleFilenames.TempDirectory))
      {
        DeleteTempDirectory();
      }
      Directory.CreateDirectory(SampleFilenames.TempDirectory);
    }

  }
}
