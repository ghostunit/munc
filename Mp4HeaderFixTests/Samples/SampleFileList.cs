using System.IO;
using Mp4HeaderFix;

namespace Mp4HeaderFixTests.Samples
{
  class SampleFileList
  {
    SampleFilenames files;
    SampleByteArrays bytes;

    public SampleFileList()
    {
      this.files = new SampleFilenames();
      this.bytes = new SampleByteArrays();

      CreateTempDirectory();
      CreateSampleFiles();
    }

    private void CreateSampleFiles()
    {
      for (int i = 1; i <= 15; i++)
      {
        byte[] b = bytes.ArrayToSearch;
        WriteFile f = new WriteFile(b, this.files.TempDirectory + "SampleFile_00" + i + ".bin");
      }
    }

    private void CreateTempDirectory()
    {
      if (Directory.Exists(this.files.TempDirectory))
      {
        Directory.Delete(this.files.TempDirectory, true);
      }
      Directory.CreateDirectory(this.files.TempDirectory);
    }

  }
}
