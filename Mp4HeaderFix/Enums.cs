namespace Mp4HeaderFix
{
  public enum ReadFileResult
  {
    Undefined,
    Success,
    IllegalFilename,
    PathNotFound,
    PermissionFailure,
    UnknownError
  }

  public enum WriteFileResult
  {
    Undefined,
    Success,
    IllegalFilename,
    NoDataToSave,
    PermissionsDenied,
    UnknownError
  }
}
