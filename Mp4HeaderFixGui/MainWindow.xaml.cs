using System;
using System.Windows;
using System.Windows.Input;
using Mp4HeaderFix;
using System.Windows.Controls;

namespace Mp4HeaderFixGui
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      this.btnSelectSource.MouseUp += btnSelectSource_MouseUp;
      this.txtFilenamePrefix.TextChanged += txtFilenamePrefixOrSuffix_TextChanged;
      this.txtFilenameSuffix.TextChanged += txtFilenamePrefixOrSuffix_TextChanged;
    }

    private Mp4RepairJob LaunchRepairJob()
    {
      Dimension orginalDimensions = new Dimension(this.txtOriginalDimensionsWidth.Text.ToUInt16(), this.txtOriginalDimensionsHeight.Text.ToUInt16());
      Dimension actualDimensions = new Dimension(this.txtActualDimensionsWidth.Text.ToUInt16(), this.txtActualDimensionsHeight.Text.ToUInt16());
      FileSaveRule fileSaveRule = new FileSaveRule(this.txtFilenamePrefix.Text, this.txtFilenameSuffix.Text, this.txtDestinationPath.Text);
      return new Mp4RepairJob(this.txtSourcePath.Text, orginalDimensions, actualDimensions, fileSaveRule);
    }

    private void btnSelectSource_MouseUp(object sender, MouseButtonEventArgs e)
    {
      this.txtSourcePath.Text = "Hello, world";
    }

    private void txtFilenamePrefixOrSuffix_TextChanged(object sender, EventArgs e)
    {
      this.lblExampleFilename.Text = this.txtFilenamePrefix.Text + "ExampleFilename" + this.txtFilenameSuffix.Text;
    }

  }
}
