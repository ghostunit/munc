using System;
using System.IO;
using Mp4HeaderFix;

namespace MhfConsoleApp
{
  static class Program
  {
    static void Main(string[] args)
    {
      string path = @"c:\temp\test.mp4";
      string newPath = @"c:\temp\fixed\";
      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);
      FileSaveRule fileSaveRule = new FileSaveRule("", "", newPath);

      Mp4RepairJob fixxer = new Mp4RepairJob(path, oldDimensions, newDimensions, fileSaveRule);
      
      LoadFile originalFile = LoadOriginalFile();
      WriteNewFile(ReplaceDimensionsInFile(originalFile));

      EndProgram();
    }

    private static void EndProgram()
    {
      Console.WriteLine("Press enter to quit.");
      Console.ReadLine();
    }

    private static void WriteNewFile(byte[] newBytes)
    {
      string newFilename = @"D:\tempFIX.mp4";
      WriteFile newFile = new WriteFile(newBytes, newFilename);
      if (newFile.Result != WriteFileResult.Success)
      {
        Console.WriteLine("File was not saved.");
      }
    }

    private static byte[] ReplaceDimensionsInFile(LoadFile originalFile)
    {
      Dimension oldDimensions = new Dimension(320, 240);
      Dimension newDimensions = new Dimension(640, 480);


      byte[] newBytes = originalFile.Bytes.ReplaceBytes(oldDimensions.AsBytes, newDimensions.AsBytes);
      return newBytes;
    }

    private static LoadFile LoadOriginalFile()
    {
      Console.WriteLine("Loading original file...");

      string filename = @"c:\temp.mp4";
      LoadFile originalFile = new LoadFile(filename);
      if (originalFile.Result != ReadFileResult.Success)
      {
        Console.WriteLine("File was not loaded.");
      }
      return originalFile;
    }

  }
}