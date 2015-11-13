using System;
using System.IO;
using Mp4HeaderFix;

namespace MhfConsoleApp
{
  static class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Starting to read binary file...");

      byte[] oldDimensions = new byte[] { 0x01, 0x40, 0x00, 0xF0 };
      byte[] newDimensions = new byte[] { 0x02, 0x80, 0x01, 0xE0 };
      string filename = @"c:\temp.mp4";
      string newFilename = @"D:\tempFIX.mp4";

      LoadFile originalFile = new LoadFile(filename);
      /*
      if (originalFile.Result == FileLoadResult.Loaded)
      {
        byte[] newFile = originalFile.Bytes.ReplaceBytes(oldDimensions, newDimensions);
        new WriteFile(newFile, newFilename);
      }
      */
      Console.WriteLine("Press enter to quit.");
      Console.ReadLine();
    }

  }
}