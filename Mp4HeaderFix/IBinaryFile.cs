using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp4HeaderFix
{
  interface IBinaryFile
  {
    string Path { get; }
    byte[] Bytes { get; }
  }
}
