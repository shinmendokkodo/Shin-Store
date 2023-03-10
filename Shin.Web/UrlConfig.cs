namespace Shin.Web;

public static class UrlConfig
{
    public static string ProductApiBase { get; set; }

    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
