using System.Threading.Tasks;
using System.Windows;
using Mp4UnCropper;
using System;

namespace Mp4UnCropperGui
{
  /// <summary>
  /// Interaction logic for DisplayResults.xaml
  /// </summary>
  public partial class DisplayResults : Window
  {
    private int jobsToProcess;

    public DisplayResults(Mp4RepairJob mp4RepairJob)
    {
      InitializeComponent();

      mp4RepairJob.FileListUpdated += new FileListUpdatedEventHandler(HandleUpdatedFileList);
      mp4RepairJob.FileProcessed += new FileProcessedEventHandler(HandleProcessedFile);
      mp4RepairJob.JobComplete += new JobCompleteEventHandler(HandleJobComplete);

      this.Show();

      Run(mp4RepairJob);

      //tbAllJobs.Text = mp4RepairJob.Results.Count.ToString() + " total jobs run.";
      //tbSuccessfulJobs.Text = mp4RepairJob.Results.FindAll(j => j.Passed).Count.ToString() + " successful repairs made.";
      //tbLoadFailures.Text = mp4RepairJob.Results.FindAll(j => j.FailurePoint == FailureType.Load).Count.ToString() + " load failures.";
      //tbModifyFailures.Text = mp4RepairJob.Results.FindAll(j => j.FailurePoint == FailureType.Modify).Count.ToString() + " files were not repaired.";
      //tbWriteFailures.Text = mp4RepairJob.Results.FindAll(j => j.FailurePoint == FailureType.Write).Count.ToString() + " write failures.";
    }

    private async void Run(Mp4RepairJob mp4RepairJob)
    {
      /*
      var progress = new Progress<int>(UpdateProgress);
      await Task.Run(() => mp4RepairJob.Run(progress));
      */
    }

    private void UpdateProgress(int e)
    {
      progressBar.Value = e / jobsToProcess;
    }

    private void HandleUpdatedFileList(object sender, FileListUpdatedEventArgs e)
    {
      jobsToProcess = e.FilesToProcess;
    }

    private void HandleProcessedFile(object sender, FileProcessedEventArgs e)
    {
      if (jobsToProcess != 0)
      {
        progressBar.Value = (e.ProcessedFiles / jobsToProcess) * 100;
      }
    }

    private void HandleJobComplete(object sender, EventArgs e)
    {
      progressBar.Visibility = System.Windows.Visibility.Hidden;
    }

  }
}