using System.Windows;
using Mp4UnCropper;

namespace Mp4UnCropperGui
{
  /// <summary>
  /// Interaction logic for DisplayResults.xaml
  /// </summary>
  public partial class DisplayResults : Window
  {
    public DisplayResults(Mp4RepairJob mp4RepairJob)
    {
      InitializeComponent();
      tbAllJobs.Text = mp4RepairJob.Results.Count.ToString() + " total jobs run.";
      tbSuccessfulJobs.Text = mp4RepairJob.Results.FindAll(j => j.Passed).Count.ToString() + " successful repairs made.";
      tbLoadFailures.Text = mp4RepairJob.Results.FindAll(j => j.FailurePoint == FailureType.Load).Count.ToString() + " load failures.";
      tbModifyFailures.Text = mp4RepairJob.Results.FindAll(j => j.FailurePoint == FailureType.Modify).Count.ToString() + " files were not repaired.";
      tbWriteFailures.Text = mp4RepairJob.Results.FindAll(j => j.FailurePoint == FailureType.Write).Count.ToString() + " write failures.";
      this.Show();
    }
  }
}
