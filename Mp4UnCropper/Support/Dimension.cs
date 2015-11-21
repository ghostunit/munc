using System;

namespace Mp4UnCropper
{
  /// <summary>
  /// Represents the width and height in pixels of a video file.
  /// </summary>
  public class Dimension
  {
    private UInt16 horizontal;
    private UInt16 vertical;

    /// <summary>
    /// Initializes a new instance of the <see cref="Dimension"/> class.
    /// </summary>
    /// <param name="horizontal">The width in pixels</param>
    /// <param name="vertical">The height in pixels</param>
    public Dimension(UInt16 horizontal, UInt16 vertical)
    {
      this.horizontal = horizontal;
      this.vertical = vertical;
    }

    internal byte[] AsBytes
    {
      get { return ReturnDimensionsAsByteArray(); }
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
