namespace WebNetSample.Core.CrossCuttingConcerns.Logging;

public class LogDetail
{
    public string MethodName { get; set; }

    public List<LogParameter> LogParameters { get; set; }

    public string FolderLocation { get; set; }
}