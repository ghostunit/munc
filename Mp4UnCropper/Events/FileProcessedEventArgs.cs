namespace Mp4UnCropper
{
  public class FileProcessedEventArgs
  {
    public FileProcessedEventArgs(int processedFiles)
    {
      ProcessedFiles = processedFiles;
    }

    public int ProcessedFiles { get; private set; }
  }
}