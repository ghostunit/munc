using System;
using System.Windows;
using Mp4HeaderFix;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;
using System.Windows.Media;

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

      #region Event Subscriptions

      // Validate paths
      this.txtSourcePath.TextChanged += txtSourcePath_ValidateSourcePath;
      this.txtDestinationPath.TextChanged += txtDestinationPath_ValidateDestinationPath;

      // Validate dimensions
      this.txtOriginalDimensionsWidth.TextChanged += txtDimensions_ValidateDimension;
      this.txtOriginalDimensionsHeight.TextChanged += txtDimensions_ValidateDimension;
      this.txtActualDimensionsWidth.TextChanged += txtDimensions_ValidateDimension;
      this.txtActualDimensionsHeight.TextChanged += txtDimensions_ValidateDimension;

      // Validate filename modifiers
      this.txtFilenamePrefix.TextChanged += txtFilenamePrefix_ValidatePrefix;
      this.txtFilenameSuffix.TextChanged += txtFilenameSuffix_ValidateSuffix;

      // Display modified filename
      this.txtFilenamePrefix.TextChanged += txtFilenamePrefixOrSuffix_TextChanged;
      this.txtFilenameSuffix.TextChanged += txtFilenamePrefixOrSuffix_TextChanged;

      #endregion

    }

    private Mp4RepairJob LaunchRepairJob()
    {
      Dimension orginalDimensions = new Dimension(this.txtOriginalDimensionsWidth.Text.ToUInt16(), this.txtOriginalDimensionsHeight.Text.ToUInt16());
      Dimension actualDimensions = new Dimension(this.txtActualDimensionsWidth.Text.ToUInt16(), this.txtActualDimensionsHeight.Text.ToUInt16());
      FileSaveRule fileSaveRule = new FileSaveRule(this.txtFilenamePrefix.Text, this.txtFilenameSuffix.Text, this.txtDestinationPath.Text);
      return new Mp4RepairJob(this.txtSourcePath.Text, orginalDimensions, actualDimensions, fileSaveRule);
    }

    #region Event Methods

    #region Validation Event Methods

    private void txtFilenamePrefix_ValidatePrefix(object sender, EventArgs e)
    {
      WatermarkTextBox textBox = sender as WatermarkTextBox;

      if (textBox.Text.IsValidFilenamePrefix())
      {
        textBox.ClearValue(Border.BorderBrushProperty);
      }
      else
      {
        textBox.BorderBrush = Brushes.Red;
      }
    }

    private void txtFilenameSuffix_ValidateSuffix(object sender, EventArgs e)
    {
      WatermarkTextBox textBox = sender as WatermarkTextBox;

      if (textBox.Text.IsValidFilenameSuffix())
      {
        textBox.ClearValue(Border.BorderBrushProperty);
      }
      else
      {
        textBox.BorderBrush = Brushes.Red;
      }
    }

    private void txtDimensions_ValidateDimension(object sender, EventArgs e)
    {
      WatermarkTextBox textBox = sender as WatermarkTextBox;

      if (textBox.Text.IsValidDimension())
      {
        textBox.ClearValue(Border.BorderBrushProperty);
      }
      else
      {
        textBox.BorderBrush = Brushes.Red;
      }
    }

    private void txtSourcePath_ValidateSourcePath(object sender, EventArgs e)
    {
      WatermarkTextBox textBox = sender as WatermarkTextBox;

      if (textBox.Text.IsValidSourcePath())
      {
        textBox.ClearValue(Border.BorderBrushProperty);
      }
      else
      {
        textBox.BorderBrush = Brushes.Red;
      }
    }

    private void txtDestinationPath_ValidateDestinationPath(object sender, EventArgs e)
    {
      WatermarkTextBox textBox = sender as WatermarkTextBox;

      if (textBox.Text.IsValidDestinationPath())
      {
        textBox.ClearValue(Border.BorderBrushProperty);
      }
      else
      {
        textBox.BorderBrush = Brushes.Red;
      }
    }

    #endregion

    private void txtFilenamePrefixOrSuffix_TextChanged(object sender, EventArgs e)
    {
      this.lblExampleFilename.Text = this.txtFilenamePrefix.Text + "ExampleFilename" + this.txtFilenameSuffix.Text;
    }

    #endregion

  }
}
