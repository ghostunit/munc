using System;
using System.IO;
using System.Linq;

namespace Mp4UnCropperGui
{
  internal static class Validation
  {
    internal static bool IsValidDimension(this string stringToTest)
    {
      bool result = false;
      UInt16 temp;

      if (UInt16.TryParse(stringToTest, out temp))
      {
        result = true;
      }

      return result;
    }

    internal static bool IsValidFilenamePrefix(this string stringToTest)
    {
      bool result = true;

      if (String.IsNullOrEmpty(stringToTest))
      {
        return true;
      }

      if (!Char.IsLetter(stringToTest[0]))
      {
        result = false;
      }
      
      if (stringToTest.Any(Path.GetInvalidFileNameChars().Contains))
      {
        result = false;
      }

      return result;
    }

    internal static bool IsValidFilenameSuffix(this string stringToTest)
    {
      bool result = true;

      if (String.IsNullOrEmpty(stringToTest))
      {
        return true;
      }

      if (stringToTest.Any(Path.GetInvalidFileNameChars().Contains))
      {
        result = false;
      }

      return result;
    }

    internal static bool IsValidSourcePath(this string stringToTest)
    {
      bool result = true;

      if (String.IsNullOrEmpty(stringToTest))
      {
        result = false;
      }

      try
      {
        Path.GetFullPath(stringToTest);
      }
      catch (Exception ex)
      {
        result = false;
      }

      return result;
    }

    internal static bool IsValidDestinationPath(this string stringToTest)
    {
      bool result = true;

      if (String.IsNullOrEmpty(stringToTest))
      {
        return false;
      }

      if (stringToTest.Any(Path.GetInvalidPathChars().Contains))
      {
        result = false;
      }

      return result;
    }

    internal static string AppendBackslashIfNecessary(this string stringToTest)
    {
      string result = String.Empty;

      if (stringToTest.EndsWith(@"\"))
      {
        result = stringToTest;
      }
      else
      {
        result = stringToTest + @"\";
      }

      return result;
    }

    internal static bool DoPathsMatch(string sourcePath, string destinationPath)
    {
      bool result = true;

      destinationPath = destinationPath.AppendBackslashIfNecessary();

      if (sourcePath == destinationPath)
      {
        result = false;
      }

      try
      {
        FileAttributes fileAttributes = File.GetAttributes(sourcePath);
        if (!fileAttributes.HasFlag(FileAttributes.Directory))
        {
          sourcePath = Path.GetDirectoryName(sourcePath);
        }
      }
      catch (Exception ex)
      {
        result = false;
      }

      if (sourcePath == destinationPath)
      {
        result = false;
      }

      return result;
    }

  }
}
