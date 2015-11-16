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

    public static Mp4RepairJob NoFilesExist()
    {
      CreateTempDirectory();

      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);
      FileSaveRule fileSaveRule = new FileSaveRule("", "", SampleFilenames.TempDestinationDirectory);

      return new Mp4RepairJob(SampleFilenames.TempDirectory, oldDimensions, newDimensions, fileSaveRule);
    }

    public static Mp4RepairJob SourceContainsIllegalFilenames()
    {
      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);
      FileSaveRule fileSaveRule = new FileSaveRule("", "", SampleFilenames.TempDestinationDirectory);
      return new Mp4RepairJob(SampleFilenames.FileWithIllegalCharacters, oldDimensions, newDimensions, fileSaveRule);
    }

    public static Mp4RepairJob OneFileWithoutOldDimensions()
    {
      CreateTempDirectory();
      CreateSampleFilesWithStandardByteArray();

      SampleBinaryFile sampleBinaryFile = new SampleBinaryFile(SampleFilenames.TempDirectory + "SampleFile_0007.mp4", SampleByteArrays.ArrayToSearchWithoutPattern, FileResult.Success);
      WriteFile overwriteOneFile = new WriteFile(sampleBinaryFile);

      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);
      FileSaveRule fileSaveRule = new FileSaveRule("", "", SampleFilenames.TempDestinationDirectory);

      return new Mp4RepairJob(SampleFilenames.TempDirectory, oldDimensions, newDimensions, fileSaveRule);
    }

    public static Mp4RepairJob SomeNonMp4Files()
    {
      CreateTempDirectory();
      CreateSampleFilesAndNonMp4Files();

      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);
      FileSaveRule fileSaveRule = new FileSaveRule("", "", SampleFilenames.TempDestinationDirectory);

      return new Mp4RepairJob(SampleFilenames.TempDirectory, oldDimensions, newDimensions, fileSaveRule);
    }

    public static Mp4RepairJob DestinationHasIllegalFilenames()
    {
      CreateTempDirectory();
      CreateSampleFilesAndNonMp4Files();

      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);
      FileSaveRule fileSaveRule = new FileSaveRule("", "", SampleFilenames.FileWithIllegalCharacters);

      return new Mp4RepairJob(SampleFilenames.TempDirectory, oldDimensions, newDimensions, fileSaveRule);
    }

    private static void CreateTempDirectory()
    {
      if (Directory.Exists(SampleFilenames.TempDirectory))
      {
        DeleteTempDirectory();
      }
      Directory.CreateDirectory(SampleFilenames.TempDirectory);
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
        WriteFile f = new WriteFile(new SampleBinaryFile(SampleFilenames.TempDirectory + "SampleFile_00" + i.ToString("D2") + ".mp4", b, FileResult.Success));
      }
    }

    private static void CreateSampleFilesAndNonMp4Files()
    {
      for (int i = 1; i <= 15; i++)
      {
        byte[] b = SampleByteArrays.ArrayToSearch;
        WriteFile f = new WriteFile(new SampleBinaryFile(SampleFilenames.TempDirectory + "SampleFile_00" + i.ToString("D2") + ".mp4", b, FileResult.Success));
      }
      for (int i = 1; i <= 15; i++)
      {
        byte[] b = SampleByteArrays.ArrayToSearch;
        WriteFile f = new WriteFile(new SampleBinaryFile(SampleFilenames.TempDirectory + "SampleFile_00" + i.ToString("D2") + ".bin", b, FileResult.Success));
      }
    }
  }
}
