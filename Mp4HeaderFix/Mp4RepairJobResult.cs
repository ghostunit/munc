using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp4HeaderFix
{
  class Mp4RepairJobResult
  {
    private int jobID;
    private string originalPath;
    private string newPath;
    private ReadFileResult readFileResult;
    private ModifyFileResult replaceBytesResult;
    private WriteFileResult writeFileResult;


  }
}
