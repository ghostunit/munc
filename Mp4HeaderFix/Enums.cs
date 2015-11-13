namespace Mp4HeaderFix
{
  public enum FileLoadResult
  {
    Undefined,
    Loaded,
    IllegalFilename,
    FileNotFound,
    PermissionFailure
  }

  public enum FileWriteResult
  {
    Undefined,
    Saved,
    IllegalFilename,
    NoDataToSave,
    PermissionsDenied
  }
}
