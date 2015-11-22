namespace Mp4UnCropper
{
  public class FileListUpdatedEventArgs
  {
    public FileListUpdatedEventArgs(int filesToProcess)
    {
      FilesToProcess = filesToProcess;
    }

    public int FilesToProcess { get; private set; }
  }
}