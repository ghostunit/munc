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

  public enum ModifyFileResult
  {
    Undefined,
    Success,
    NoFileToModify,
    PatternNotFound,
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
