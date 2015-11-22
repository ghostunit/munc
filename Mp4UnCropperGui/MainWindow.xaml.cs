using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.WindowsAPICodePack.Dialogs;
using Mp4UnCropper;
using Xceed.Wpf.Toolkit;

namespace Mp4UnCropperGui
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

      // Button events
      this.btnOk.Click += btnOk_Click;
      this.btnSourceFile.Click += btnSourceFile_Click;
      this.btnSourceFolder.Click += btnSourceFolder_Click;
      this.btnSelectDestination.Click += btnSelectDestination_Click;

      #endregion

    }

    private Mp4RepairJob PrepareRepairJob()
    {
      String sourcePath = String.Empty;
      Dimension orginalDimensions = new Dimension(0, 0);
      Dimension actualDimensions = new Dimension(0, 0);
      FileSaveRule fileSaveRule = new FileSaveRule(string.Empty, string.Empty, string.Empty);

      if (ValidateMp4RepairJob())
      {
        sourcePath = this.txtSourcePath.Text;
        orginalDimensions = new Dimension(this.txtOriginalDimensionsWidth.Text.ToUInt16(), this.txtOriginalDimensionsHeight.Text.ToUInt16());
        actualDimensions = new Dimension(this.txtActualDimensionsWidth.Text.ToUInt16(), this.txtActualDimensionsHeight.Text.ToUInt16());
        fileSaveRule = new FileSaveRule(this.txtFilenamePrefix.Text, this.txtFilenameSuffix.Text, this.txtDestinationPath.Text.AppendBackslashIfNecessary());
      }

      Mp4RepairJob mp4RepairJob = new Mp4RepairJob(sourcePath, orginalDimensions, actualDimensions, fileSaveRule);

      return mp4RepairJob;
    }

    private bool ValidateMp4RepairJob()
    {
      bool result = false;
      List<bool> validationResults = new List<bool>();

      // Validate the source and destination paths
      validationResults.Add(this.txtSourcePath.Text.IsValidSourcePath());
      validationResults.Add(this.txtDestinationPath.Text.IsValidDestinationPath());

      // Validate the dimensions
      validationResults.Add(this.txtOriginalDimensionsWidth.Text.IsValidDimension());
      validationResults.Add(this.txtOriginalDimensionsHeight.Text.IsValidDimension());
      validationResults.Add(this.txtActualDimensionsWidth.Text.IsValidDimension());
      validationResults.Add(this.txtActualDimensionsHeight.Text.IsValidDimension());

      // Validate the file modification paramaters
      validationResults.Add(this.txtFilenamePrefix.Text.IsValidFilenamePrefix());
      validationResults.Add(this.txtFilenameSuffix.Text.IsValidFilenameSuffix());

      // Make sure the source and destination folders are different
      validationResults.Add(Validation.DoPathsMatch(this.txtSourcePath.Text, this.txtDestinationPath.Text));

      if (!validationResults.Contains(false))
      {
        result = true;
      }

      return result;
    }

    private void OpenFileDialogBox(string dialogTitle, TextBox textBoxToModify, bool isFolderPicker)
    {
      CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
      string currentDirectory = @"c:\";

      if (!String.IsNullOrEmpty(this.txtSourcePath.Text))
      {
        FileAttributes fileAttributes = File.GetAttributes(this.txtSourcePath.Text);
        if (fileAttributes.HasFlag(FileAttributes.Directory))
        {
          currentDirectory = this.txtSourcePath.Text;
        }
      }

      if (!isFolderPicker)
      {
        fileDialog.Filters.Add(new CommonFileDialogFilter("MP4 Video File", "*.mp4"));
      }

      fileDialog.Title = dialogTitle;
      fileDialog.IsFolderPicker = isFolderPicker;
      fileDialog.InitialDirectory = currentDirectory;
      fileDialog.AddToMostRecentlyUsedList = false;
      fileDialog.AllowNonFileSystemItems = false;
      fileDialog.DefaultDirectory = currentDirectory;
      fileDialog.EnsureFileExists = true;
      fileDialog.EnsurePathExists = true;
      fileDialog.EnsureReadOnly = false;
      fileDialog.EnsureValidNames = true;
      fileDialog.Multiselect = false;
      fileDialog.ShowPlacesList = true;

      if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
      {
        textBoxToModify.Text = fileDialog.FileName;
      }
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

    #region Path Button Clicks

    private void btnSourceFile_Click(object sender, EventArgs e)
    {
      OpenFileDialogBox("Select Source File", this.txtSourcePath, false);
    }

    private void btnSourceFolder_Click(object sender, EventArgs e)
    {
      OpenFileDialogBox("Select Source Folder", this.txtSourcePath, true);
    }

    private void btnSelectDestination_Click(object sender, EventArgs e)
    {
      OpenFileDialogBox("Select Destination Folder", this.txtDestinationPath, true);
    }

    #endregion

    private void btnOk_Click(object sender, EventArgs e)
    {
      Mp4RepairJob mp4headerJob = PrepareRepairJob();
      DisplayResults displayResults = new DisplayResults(mp4headerJob);
    }

    private void txtFilenamePrefixOrSuffix_TextChanged(object sender, EventArgs e)
    {
      this.lblExampleFilename.Text = this.txtFilenamePrefix.Text + "ExampleFilename" + this.txtFilenameSuffix.Text;
    }

    #endregion

  }
}
