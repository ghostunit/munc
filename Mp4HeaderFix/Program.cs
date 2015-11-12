using System;
using System.IO;

namespace Mp4HeaderFix
{
  static class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Starting to read binary file...");

      byte[] oldDimensions = new byte[] { 0x01, 0x40, 0x00, 0xF0 };
      byte[] newDimensions = new byte[] { 0x02, 0x80, 0x01, 0xE0 };
      string filename = @"c:\temp.mp4";
      string newFilename = @"c:\tempFIX.mp4";


      byte[] originalFile = File.ReadAllBytes(filename);
      byte[] newFile = originalFile.ReplaceBytes(oldDimensions, newDimensions);

      WriteFile(newFilename, newFile);

      EndProgram();
    }

    private static void WriteFile(string newFilename, byte[] newFile)
    {
      FileStream fileStream = new FileStream(newFilename, FileMode.Create, FileAccess.Write);
      fileStream.Write(newFile, 0, newFile.Length);
      fileStream.Close();
    }

    private static byte[] ReplaceBytes(this byte[] originalFile, byte[] oldDimensions, byte[] newData)
    {
      byte[] result = originalFile;

      FoundBytes foundBytes = new FoundBytes(oldDimensions, originalFile);

      if (foundBytes.IsMatch)
      {
        Console.WriteLine("Found at index: " + foundBytes.PatternIndex);
        result[foundBytes.PatternIndex] = newData[0];
        result[foundBytes.PatternIndex + 1] = newData[1];
        result[foundBytes.PatternIndex + 2] = newData[2];
        result[foundBytes.PatternIndex + 3] = newData[3];
      }
      else
      {
        Console.WriteLine("Could not find the specified directions in the source file.");
      }

      return result;
    }

    private static void EndProgram()
    {
      Console.WriteLine("Press enter to quit.");
      Console.ReadLine();
    }

  }
}