using System;
using System.Linq;

namespace Mp4UnCropper
{
  internal class PatternMatch
  {
    private byte[] patternToFind;
    private byte[] arrayToSearch;
    private int firstPatternIndex;

    internal PatternMatch(byte[] patternToFind, byte[] arrayToSearch)
    {
      this.patternToFind = patternToFind;
      this.arrayToSearch = arrayToSearch;
      this.firstPatternIndex = 0;
    }

    internal bool Success
    {
      get
      {
        FindFirstPatternIndex();

        if (firstPatternIndex > 0)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    internal int Index
    {
      get
      {
        FindFirstPatternIndex();
        return firstPatternIndex;
      }
    }

    private void FindFirstPatternIndex()
    {
      if (firstPatternIndex != 0)
      {
        return;
      }

      int i = IndexOfByte(arrayToSearch, patternToFind[0]);

      while (i >= 0 && i <= arrayToSearch.Length - patternToFind.Length)
      {
        byte[] segment = new byte[patternToFind.Length];
        Buffer.BlockCopy(arrayToSearch, i, segment, 0, patternToFind.Length);

        if (segment.SequenceEqual<byte>(patternToFind))
        {
          firstPatternIndex = i;
          break;
        }

        i = Array.IndexOf<byte>(arrayToSearch, patternToFind[0], i + patternToFind.Length);
      }
    }

    private int IndexOfByte(byte[] arrayToSearch, byte value)
    {
      for (int i = 0; i < arrayToSearch.Length; i++)
      {
        if (arrayToSearch[i] == value)
        {
          return i;
        }
      }

      return -1;
    }

  }
}
