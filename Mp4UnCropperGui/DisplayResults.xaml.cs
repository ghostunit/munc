using System;
using System.Threading.Tasks;
using System.Windows;
using Mp4UnCropper;

namespace Mp4UnCropperGui
{
  /// <summary>
  /// Interaction logic for DisplayResults.xaml
  /// </summary>
  public partial class DisplayResults : Window
  {
    private int jobsToProcess;
    private int successfulJobs = 0;
    private int loadFailures = 0;
    private int modifyFailures = 0;
    private int writeFailures = 0;

    public DisplayResults(Mp4RepairJob mp4RepairJob)
    {
      InitializeComponent();
      mp4RepairJob.FileListUpdated += new FileListUpdatedEventHandler(HandleUpdatedFileList);
      mp4RepairJob.JobComplete += new JobCompleteEventHandler(HandleJobComplete);
      this.Show();
      Run(mp4RepairJob);
    }

    private async void Run(Mp4RepairJob mp4RepairJob)
    {
      var progress = new Progress<JobResult>(UpdateProgress);
      await Task.Run(() => mp4RepairJob.RunAsync(progress));
    }

    private void UpdateProgress(JobResult jobResult)
    {
      ProcessJobResult(jobResult);
      UpdateGui();
    }

    private void UpdateGui()
    {
      tbAllJobs.Text = jobsToProcess.ToString() + " total jobs to run.";
      tbSuccessfulJobs.Text = successfulJobs.ToString() + " successful jobs.";
      tbLoadFailures.Text = loadFailures.ToString() + " load failures.";
      tbModifyFailures.Text = modifyFailures.ToString() + " files were not repaired.";
      tbWriteFailures.Text = writeFailures.ToString() + " write failures.";
    }

    private void ProcessJobResult(JobResult jobResult)
    {
      if (jobResult.Passed)
      {
        successfulJobs++;
      }
      else
      {
        switch (jobResult.FailurePoint)
        {
          case FailureType.Load:
            loadFailures++;
            break;

          case FailureType.Modify:
            modifyFailures++;
            break;

          case FailureType.Write:
            writeFailures++;
            break;
        }
      }
    }

    private void HandleUpdatedFileList(object sender, FileListUpdatedEventArgs e)
    {
      jobsToProcess = e.FilesToProcess;
    }

    private void HandleJobComplete(object sender, EventArgs e)
    {
      // TODO: Decide what to do with this event
    }

  }
}