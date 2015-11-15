using System;
using System.Windows;
using System.Windows.Input;

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

      this.txtOriginalDimensionsWidth.GotFocus += txtOriginalDimensionsWidth_GotFocus;
      this.txtOriginalDimensionsHeight.GotFocus += txtOriginalDimensionsHeight_GotFocus;
      this.txtActualDimensionsWidth.GotFocus += txtActualDimensionsWidth_GotFocus;
      this.txtActualDimensionsHeight.GotFocus += txtActualDimensionsHeight_GotFocus;

      this.txtOriginalDimensionsWidth.LostFocus += txtOriginalDimensionsWidth_LostFocus;
      this.txtOriginalDimensionsHeight.LostFocus += txtOriginalDimensionsHeight_LostFocus;
      this.txtActualDimensionsWidth.LostFocus += txtActualDimensionsWidth_LostFocus;
      this.txtActualDimensionsHeight.LostFocus += txtActualDimensionsHeight_LostFocus;

      this.btnSelectSource.MouseUp += btnSelectSource_MouseUp;
      this.btnSelectDestination.MouseUp += btnSelectDestination_MouseUp;

      this.txtFilenamePrefix.TextChanged += txtFilenamePrefixOrSuffix_TextChanged;
      this.txtFilenameSuffix.TextChanged += txtFilenamePrefixOrSuffix_TextChanged;
    }

    #region Dimensions Got Focus

    private void txtOriginalDimensionsWidth_GotFocus(object sender, EventArgs e)
    {
      if (this.txtOriginalDimensionsWidth.Text == "Width")
      {
        this.txtOriginalDimensionsWidth.Text = "";
      }
    }

    private void txtOriginalDimensionsHeight_GotFocus(object sender, EventArgs e)
    {
      if (this.txtOriginalDimensionsHeight.Text == "Height")
      {
        this.txtOriginalDimensionsHeight.Text = "";
      }
    }

    private void txtActualDimensionsWidth_GotFocus(object sender, EventArgs e)
    {
      if (this.txtActualDimensionsWidth.Text == "Width")
      {
        this.txtActualDimensionsWidth.Text = "";
      }
    }

    private void txtActualDimensionsHeight_GotFocus(object sender, EventArgs e)
    {
      if (this.txtActualDimensionsHeight.Text == "Height")
      {
        this.txtActualDimensionsHeight.Text = "";
      }
    }

    #endregion

    #region Dimensions Lost Focus

    private void txtOriginalDimensionsWidth_LostFocus(object sender, EventArgs e)
    {
      if (this.txtOriginalDimensionsWidth.Text == "")
      {
        this.txtOriginalDimensionsWidth.Text = "Width";
      }
    }

    private void txtOriginalDimensionsHeight_LostFocus(object sender, EventArgs e)
    {
      if (this.txtOriginalDimensionsHeight.Text == "")
      {
        this.txtOriginalDimensionsHeight.Text = "Height";
      }
    }

    private void txtActualDimensionsWidth_LostFocus(object sender, EventArgs e)
    {
      if (this.txtActualDimensionsWidth.Text == "")
      {
        this.txtActualDimensionsWidth.Text = "Width";
      }
    }

    private void txtActualDimensionsHeight_LostFocus(object sender, EventArgs e)
    {
      if (this.txtActualDimensionsHeight.Text == "")
      {
        this.txtActualDimensionsHeight.Text = "Height";
      }
    }

    #endregion

    private void txtFilenamePrefixOrSuffix_TextChanged(object sender, EventArgs e)
    {
      this.lblExampleFilename.Text = this.txtFilenamePrefix.Text + "ExampleFilename" + this.txtFilenameSuffix.Text;
    }

    private void btnSelectSource_MouseUp(object sender, MouseButtonEventArgs e)
    {
      this.txtSourcePath.Text = "Hello, world";
    }

    private void btnSelectDestination_MouseUp(object sender, MouseButtonEventArgs e)
    {
      this.txtSourcePath.Text = "Hello, world";

    }
  }
}
