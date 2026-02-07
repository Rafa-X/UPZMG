namespace UPZMG.Web.Models;

public class HomeModel
{
    public string? RequestId { get; set; }
    public List<string> Data { get; set; } = new List<string>();
}
