using System;

namespace Mp4UnCropper
{
  public delegate void FileListUpdatedEventHandler(object sender, FileListUpdatedEventArgs e);
  public delegate void FileProcessedEventHandler(object sender, FileProcessedEventArgs e);
  public delegate void JobCompleteEventHandler(object sender, EventArgs e);
}