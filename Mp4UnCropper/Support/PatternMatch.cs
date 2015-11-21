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

        if (this.firstPatternIndex > 0)
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
        return this.firstPatternIndex;
      }
    }

    private void FindFirstPatternIndex()
    {
      if (this.firstPatternIndex != 0)
      {
        return;
      }

      int i = IndexOfByte(this.arrayToSearch, this.patternToFind[0]);

      while (i >= 0 && i <= this.arrayToSearch.Length - this.patternToFind.Length)
      {
        byte[] segment = new byte[this.patternToFind.Length];
        Buffer.BlockCopy(this.arrayToSearch, i, segment, 0, this.patternToFind.Length);

        if (segment.SequenceEqual<byte>(this.patternToFind))
        {
          this.firstPatternIndex = i;
          break;
        }

        i = Array.IndexOf<byte>(this.arrayToSearch, this.patternToFind[0], i + this.patternToFind.Length);
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
