using System;

namespace Mp4UnCropper
{
  public class FileProcessedEventArgs : EventArgs
  {
    public FileProcessedEventArgs(int processedFiles)
    {
      ProcessedFiles = processedFiles;
    }

    public int ProcessedFiles { get; private set; }
  }
}