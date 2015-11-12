using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp4HeaderFix
{
  class FoundBytes
  {
    private byte[] patternToFind;
    private byte[] patternToSearch;
    private int firstPatternIndex;

    public bool IsMatch
    {
      get
      {
        IndexOfSequence();

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

    public int PatternIndex
    {
      get
      {
        IndexOfSequence();
        return this.firstPatternIndex;
      }
    }

    public FoundBytes(byte[] patternToFind, byte[] patternToSearch)
    {
      this.patternToFind = patternToFind;
      this.patternToSearch = patternToSearch;
      this.firstPatternIndex = 0;
    }

    private void IndexOfSequence()
    {
      // We only need to run this once per file
      if (this.firstPatternIndex != 0)
      {
        return;
      }

      // Find the first occurance of the first element of the pattern we're searching for
      int i = IndexOfByte(this.patternToSearch, this.patternToFind[0]);

      while (i >= 0 && i <= this.patternToSearch.Length - this.patternToFind.Length)
      {
        // Copy the potential match into a new byte array
        byte[] segment = new byte[this.patternToFind.Length];
        Buffer.BlockCopy(this.patternToSearch, i, segment, 0, this.patternToFind.Length);

        // See if this new array matches our pattern
        if (segment.SequenceEqual<byte>(this.patternToFind))
        {
          this.firstPatternIndex = i;
          break;
        }

        // Move onto the next occurance of the first element of the pattern we're searching for
        i = Array.IndexOf<byte>(this.patternToSearch, this.patternToFind[0], i + this.patternToFind.Length);
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
