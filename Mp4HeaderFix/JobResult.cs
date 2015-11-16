namespace Mp4HeaderFix
{
  public class JobResult
  {
    private int jobID;
    private string originalPath;
    private string newPath;
    private FileResult loadFileResult;
    private FileResult modifiedFileResult;
    private FileResult writeFileResult;

    /// <summary>
    /// The zero-based index of this job result
    /// </summary>
    public int JobID
    {
      get
      {
        return this.jobID;
      }
    }

    /// <summary>
    /// Returns true if the job reported a failure type of "none"
    /// </summary>
    public bool Passed
    {
      get
      {
        if (FailurePoint == FailureType.None)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    /// <summary>
    /// Gets the point in which this file's repair failed
    /// </summary>
    public FailureType FailurePoint
    {
      get
      {
        return DecideFailureType();
      }
    }

    /// <summary>
    /// Gets the result code from the earliest failure point of this file's repair
    /// </summary>
    public FileResult FailureResult
    {
      get
      {
        return GetFileResultCode();
      }
    }

    /// <summary>
    /// Gets a Human readable description of this file's repair status
    /// </summary>
    public string Status
    {
      get
      {
        return CreateHumanReadableFailureMessage();
      }
    }

    /// <summary>
    /// Gets the path and filename of the original file
    /// </summary>
    public string OriginalFilename
    {
      get
      {
        return this.originalPath;
      }
    }

    /// <summary>
    /// Gets the path and filename of the modified and saved file
    /// </summary>
    public string NewFilename
    {
      get
      {
        return newPath;
      }
    }

    internal JobResult(int jobID, LoadFile loadFile, ModifiedFile modifiedFile, WriteFile writeFile)
    {
      this.jobID = jobID;
      this.originalPath = loadFile.Path;
      this.newPath = writeFile.Path;
      this.loadFileResult = loadFile.Result;
      this.modifiedFileResult = modifiedFile.Result;
      this.writeFileResult = writeFile.Result;
    }

    private string CreateHumanReadableFailureMessage()
    {
      string result = "File was loaded, modified, and saved with no errors.";

      switch (FailurePoint)
      {
        case FailureType.Load:
          #region File load error messages

          switch (FailureResult)
          {
            case FileResult.PathNotFound:
              result = "Could not find the requested file or folder.";
              break;
            case FileResult.IllegalFilename:
              result = "Originally requested file or folder contained illegal characters.";
              break;
            case FileResult.PermissionFailure:
              result = "Could not open the requested file or folder due to a permissions error.";
              break;
            case FileResult.UnknownError:
              result = "Could not open the requested file or folder due to an unknown error.";
              break;
          }

          #endregion
          break;

        case FailureType.Modify:
          #region Modify file error messages

          switch (FailureResult)
          {
            case FileResult.NoFileToModify:
              result = "The source file either does not exist or is zero bytes.";
              break;
            case FileResult.PatternNotFound:
              result = "Could not find the dimensions anywhere within the source file.";
              break;
            case FileResult.UnknownError:
              result = "Could not modify the file due to an unknown error.";
              break;
          }

          #endregion
          break;

        case FailureType.Write:
          #region Write file error messages

          switch (FailureResult)
          {
            case FileResult.NoDataToSave:
              result = "The file to be saved either dosen't exist or is zero bytes.";
              break;

            case FileResult.IllegalFilename:
              result = "The file to be saved contained illegal characters.";
              break;
            case FileResult.PermissionFailure:
              result = "Could not save the requested file or folder due to a permissions error.";
              break;
            case FileResult.UnknownError:
              result = "Could not save the requested file or folder due to an unknown error.";
              break;
          }

          #endregion
          break;

      }
      return result;
    }

    private FailureType DecideFailureType()
    {
      FailureType result = FailureType.None;

      if (this.writeFileResult != FileResult.Success)
      {
        result = FailureType.Write;
      }
      if (this.modifiedFileResult != FileResult.Success)
      {
        result = FailureType.Modify;
      }
      if (this.loadFileResult != FileResult.Success)
      {
        result = FailureType.Load;
      }

      return result;
    }

    private FileResult GetFileResultCode()
    {
      FileResult result = FileResult.Success;
      FailureType failureType = DecideFailureType();

      switch (failureType)
      {
        case FailureType.Load:
          result = this.loadFileResult;
          break;
        case FailureType.Modify:
          result = this.modifiedFileResult;
          break;
        case FailureType.Write:
          result = this.writeFileResult;
          break;
      }

      return result;
    }
  }
}
