namespace AutomobiliuPardavimoPrograma.Models
{
public class ServiceResult
{
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }

    public static ServiceResult Success() => new ServiceResult { IsSuccess = true };
    public static ServiceResult Fail(string message) => new ServiceResult { IsSuccess = false, ErrorMessage = message };
}
}