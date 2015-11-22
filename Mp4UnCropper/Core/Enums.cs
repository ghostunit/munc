namespace Mp4UnCropper
{
  /// <summary>The result of action(s) performed on an object of type BinaryFile.</summary>
  public enum FileResult
  {
    Undefined,
    Success,
    IllegalFilename,
    PathNotFound,
    NoFileToModify,
    PatternNotFound,
    NoDataToSave,
    PermissionFailure,
    UnknownError
  }

  /// <summary>When the job failed during the repair process.</summary>
  public enum FailureType
  {
    None,
    Load,
    Modify,
    Write
  }

}
