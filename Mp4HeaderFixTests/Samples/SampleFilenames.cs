using System;
namespace Mp4HeaderFixTests.Samples
{
  public class SampleFilenames
  {
    public string Pwd = Environment.CurrentDirectory;
    public string TempDirectory = Environment.CurrentDirectory + @"\TempDirectory\";
    public string TempDirectoryWithIllegalCharacters = Environment.CurrentDirectory + @"\5&^^%@*\";
    public string FileThatExistsInTempDirectory = Environment.CurrentDirectory + @"\TempDirectory\SampleFile_001.bin";
    public string FileThatExists = Environment.CurrentDirectory + @"\TestFiles\VideoWithBadHeader.mp4";
    public string FileThatDoesNotExist = @"c:\doesNotExist.mp4";
    public string FileWithIllegalCharacters = ":sd34/.,";
    public string TemporaryFileToWrite = @"c:\temp\Mp4HeaderFix_001.bin";
  }
}