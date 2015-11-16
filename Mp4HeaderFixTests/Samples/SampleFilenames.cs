using System;
namespace Mp4HeaderFixTests.Samples
{
  public static class SampleFilenames
  {
    public static string Pwd = Environment.CurrentDirectory;
    public static string TempDirectory = Environment.CurrentDirectory + @"\TempDirectory\";
    public static string TempDestinationDirectory = Environment.CurrentDirectory + @"\TempDirectory\Converted\";
    public static string TempDirectoryWithIllegalCharacters = Environment.CurrentDirectory + @"\5&^^%@*\";
    public static string FileThatExistsInTempDirectory = Environment.CurrentDirectory + @"\TempDirectory\SampleFile_0001.mp4";
    public static string FileThatExists = Environment.CurrentDirectory + @"\TestFiles\VideoWithBadHeader.mp4";
    public static string FileThatDoesNotExist = @"c:\doesNotExist.mp4";
    public static string FileWithIllegalCharacters = ":sd34/.,";
    public static string TemporaryFileToWrite = @"c:\temp\Mp4HeaderFix_001.mp4";
  }
}