﻿using System;
using System.IO;

namespace Mp4HeaderFix
{
  public class LoadFile : IBinaryFile
  {
    private string filename;
    private byte[] fileAsBytes;
    private ReadFileResult readFileResult;

    public string Path
    {
      get
      {
        return this.filename;
      }
    }

    public ReadFileResult Result
    {
      get
      {
        return this.readFileResult;
      }
    }

    public byte[] Bytes
    {
      get
      {
        return this.fileAsBytes;
      }
    }

    public LoadFile(string filename)
    {
      this.filename = filename;
      this.fileAsBytes = new byte[0];
      this.readFileResult = ReadFileResult.Undefined;
      Load();
    }

    private void Load()
    {
      if (this.readFileResult != ReadFileResult.Undefined)
      {
        return;
      }

      try
      {
        System.IO.Path.GetFullPath(this.filename);
      }
      catch (Exception ex)
      {
        this.readFileResult = ReadFileResult.IllegalFilename;
        return;
      }

      try
      {
        this.fileAsBytes = File.ReadAllBytes(this.filename);
      }
      catch (FileNotFoundException ex)
      {
        this.readFileResult = ReadFileResult.PathNotFound;
        return;
      }

      if (this.fileAsBytes != null && this.fileAsBytes.Length > 0)
      {
        this.readFileResult = ReadFileResult.Success;
      }
    }

  }
}
