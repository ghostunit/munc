using System;
using System.Collections.Generic;

namespace Mp4UnCropper
{
  /// <summary>Represents one complete MP4 header repair job, including the files to be converted and the changes to make.</summary>
  public class Mp4RepairJob
  {
    private string pathToOriginalFiles;
    private Dimension oldDimensions;
    private Dimension newDimensions;
    private FileSaveRule fileSaveRule;
    private List<JobResult> jobResults;

    /// <summary>Initializes a new instance of the <see cref="Mp4RepairJob"/> class.</summary>
    /// <param name="pathToOriginalFiles">A string referencing the file or folder to be processed</param>
    /// <param name="oldDimensions">The dimensions that are incorrectly stored on the source MP4 file(s)</param>
    /// <param name="newDimensions">The correct dimensions of the MP4 file(s)</param>
    /// <param name="fileSaveRule">The destination and naming conventions to use for the converted files</param>
    public Mp4RepairJob(string pathToOriginalFiles, Dimension oldDimensions, Dimension newDimensions, FileSaveRule fileSaveRule)
    {
      this.pathToOriginalFiles = pathToOriginalFiles;
      this.oldDimensions = oldDimensions;
      this.newDimensions = newDimensions;
      this.fileSaveRule = fileSaveRule;
      this.jobResults = new List<JobResult>();
    }

    /// <summary>Occurs when the MP4RepairJob determines how many files are to be processed.</summary>
    public event FileListUpdatedEventHandler FileListUpdated;

    /// <summary>Occurs when an MP4 file has been processed.</summary>
    public event FileProcessedEventHandler FileProcessed;

    /// <summary>Occurs after the last MP4RepairJob has been run.</summary>
    public event JobCompleteEventHandler JobComplete;

    /// <summary>Gets a list of results for this job, one for each file that was repaired.</summary>
    public List<JobResult> Results
    {
      get { return jobResults; }
    }

    /// <summary>Runs the MP4 repair job. Loads, modifies and writes each of the source file(s) and records the results of that repair.</summary>
    public void Run()
    {
      int jobID = 0;
      List<string> filenames = new FileList(pathToOriginalFiles).Files;
      filenames.Sort();
      SendFileListUpdatedEvent(filenames.Count);

      foreach (string filename in filenames)
      {
        var loadFile = new LoadFile(filename);
        var destination = new Destination(fileSaveRule, loadFile.Path);
        var modifiedFile = new ModifiedFile(loadFile.Bytes, oldDimensions.AsBytes, newDimensions.AsBytes, destination.Path);
        var writeFile = new WriteFile(modifiedFile);
        var jobResult = new JobResult(jobID, loadFile, modifiedFile, writeFile);
        jobResults.Add(jobResult);
        SendFileProcessedEvent(jobResults.Count);
        jobID++;
      }

      SendJobCompleteEvent();
    }

    private void SendFileListUpdatedEvent(int filesToProcess)
    {
      var eventArgs = new FileListUpdatedEventArgs(filesToProcess);

      if (FileListUpdated != null)
      {
        FileListUpdated(this, eventArgs);
      }
    }

    private void SendFileProcessedEvent(int filesProcessed)
    {
      var eventArgs = new FileProcessedEventArgs(filesProcessed);

      if (FileProcessed != null)
      {
        FileProcessed(this, eventArgs);
      }
    }

    private void SendJobCompleteEvent()
    {
      if (JobComplete != null)
      {
        JobComplete(this, new EventArgs());
      }
    }

  }
}