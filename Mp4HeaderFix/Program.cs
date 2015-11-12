using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mp4HeaderFix
{
  class Program
  {
    static void Main(string[] args)
    {
      byte[] oldDimensions = new byte[] { 0x01, 0x40, 0x00, 0xF0 };
      byte[] newData = new byte[] { 0x02, 0x80, 0x01, 0xE0 };
      string filename = @"c:\temp.mp4";

      BinaryFile originalFile = new BinaryFile(filename);

      Console.WriteLine("Starting to read binary file...");

      Console.WriteLine("Press enter to quit.");
      Console.ReadLine();
    }

    static int findResolution(byte[] file, byte[] dimensions)
    {
      int result = 0;

      bool foundSequence = false;
      int sequenceindexStart = 0;

      for (int i = 0; i < file.Length; i++)
      {
        if (file[i] == dimensions[0])
        {
          Console.WriteLine("Found first byte.");
          sequenceindexStart = i;
          if (file[i + 1] == dimensions[1])
          {
            Console.WriteLine("Found second byte.");
            if (file[i + 2] == dimensions[2])
            {
              Console.WriteLine("Found third byte.");
              if (file[i + 3] == dimensions[3])
              {
                foundSequence = true;
                Console.WriteLine("Found fourth byte.");
                Console.WriteLine("Complete hex sequence found at index " + sequenceindexStart.ToString());
              }
            }
          }

          if (foundSequence)
          {
            break;
          }
        }

        return result;
      }
    }
  }
}