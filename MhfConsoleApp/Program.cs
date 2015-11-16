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
      fixxer.Run();
      
      EndProgram();
    }

    private static void EndProgram()
    {
      Console.WriteLine("Press enter to quit.");
      Console.ReadLine();
    }

  }
}