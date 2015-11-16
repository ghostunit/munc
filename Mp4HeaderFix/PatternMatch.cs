using System;
using System.Linq;

namespace Mp4HeaderFix
{
  public class PatternMatch
  {
    private byte[] patternToFind;
    private byte[] arrayToSearch;
    private int firstPatternIndex;

    /// <summary>
    /// Returns true if an instance of the pattern was found in the array.
    /// </summary>
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

    /// <summary>
    /// The zero-based index of the pattern found within the array.
    /// </summary>
    internal int Index
    {
      get
      {
        FindFirstPatternIndex();
        return this.firstPatternIndex;
      }
    }

    /// <summary>
    /// Searches within a byte array for the first instance of another byte array.
    /// </summary>
    /// <param name="patternToFind">The byte array to find within the larger array</param>
    /// <param name="arrayToSearch">The byte array to search inside of</param>
    internal PatternMatch(byte[] patternToFind, byte[] arrayToSearch)
    {
      this.patternToFind = patternToFind;
      this.arrayToSearch = arrayToSearch;
      this.firstPatternIndex = 0;
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
