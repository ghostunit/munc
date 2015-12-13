using System;

namespace Mp4UnCropper
{
  public class FileListUpdatedEventArgs : EventArgs
  {
    public FileListUpdatedEventArgs(int filesToProcess)
    {
      FilesToProcess = filesToProcess;
    }

    public int FilesToProcess { get; private set; }
  }
}