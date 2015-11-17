using System.Collections.Generic;

namespace Mp4HeaderFix
{
  /// <summary>
  /// Represents one complete MP4 header repair job, including the files to be converted and the changes to make
  /// </summary>
  public class Mp4RepairJob
  {
    private string pathToOriginalFiles;
    private Dimension oldDimensions;
    private Dimension newDimensions;
    private FileSaveRule fileSaveRule;
    private List<JobResult> jobResults;

    /// <summary>
    /// Gets a list of results for this job, one for each file that was repaired
    /// </summary>
    public List<JobResult> Results
    {
      get { return this.jobResults; }
    }

    /// <summary>
    /// This is the only way to properly initialize this object.
    /// </summary>
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

    /// <summary>
    /// Runs the MP4 repair job. Loads, modifies and writes each of the source file(s) ad records the results of that repair
    /// </summary>
    public void Run()
    {
      int jobID = 0;
      List<string> filenames = new FileList(this.pathToOriginalFiles).Files;
      filenames.Sort();

      foreach (string filename in filenames)
      {
        LoadFile loadFile = new LoadFile(filename);
        Destination destination = new Destination(this.fileSaveRule, loadFile.Path);
        ModifiedFile modifiedFile = new ModifiedFile(loadFile.Bytes, this.oldDimensions.AsBytes, this.newDimensions.AsBytes, destination.Path);
        WriteFile writeFile = new WriteFile(modifiedFile);
        JobResult jobResult = new JobResult(jobID, loadFile, modifiedFile, writeFile);
        this.jobResults.Add(jobResult);
        jobID++;
      }

    }

  }
}
