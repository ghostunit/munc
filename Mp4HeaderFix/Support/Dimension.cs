using System;

namespace Mp4HeaderFix
{
  /// <summary>
  /// Represents the width and height in pixels of a video file.
  /// </summary>
  public class Dimension
  {
    private UInt16 horizontal;
    private UInt16 vertical;

    internal byte[] AsBytes
    {
      get
      {
        return ReturnDimensionsAsByteArray();
      }
    }

    public Dimension(UInt16 horizontal, UInt16 vertical)
    {
      this.horizontal = horizontal;
      this.vertical = vertical;
    }

    private byte[] ReturnDimensionsAsByteArray()
    {
      byte[] result = new byte[4];

      byte[] h = this.horizontal.GetBytes();
      byte[] v = this.vertical.GetBytes();

      result[0] = h[0];
      result[1] = h[1];
      result[2] = v[0];
      result[3] = v[1];

      return result;
    }

  }
}
