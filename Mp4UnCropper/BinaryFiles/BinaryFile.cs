using NLog;

namespace Mp4UnCropper
{
  internal class BinaryFile
  {
    protected BinaryFile()
    {
      Logger = LogManager.GetLogger(GetType().FullName);
    }

    protected internal string Path { get; protected set; }

    protected internal byte[] Bytes { get; protected set; }
    
    protected internal FileResult Result { get; protected set; }

    protected Logger Logger { get; private set; }

    protected string LogPrefix { get; set; }

  }
}