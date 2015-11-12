using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mp4HeaderFix
{
  public class BinaryFile
  {
    private string filename;
    private byte[] bytes;

    public byte[] Bytes
    {
      get { return bytes; }
    }

    public BinaryFile(string filename)
    {
      this.filename = filename;
      this.bytes = File.ReadAllBytes(this.filename);
    }

  }
}
