namespace Mp4UnCropper
{
  internal class BinaryFile
  {
    protected string filename;
    protected byte[] fileAsBytes;
    protected FileResult fileResult;

    internal string Path
    {
      get
      {
        return this.filename;
      }
    }

    internal byte[] Bytes
    {
      get
      {
        return this.fileAsBytes;
      }
    }

    internal FileResult Result
    {
      get
      {
        return this.fileResult;
      }
    }
  }
}