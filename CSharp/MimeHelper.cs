public class MimeHelper : IMimeHelper
{
    public string GetContentType(string path) {
        var found = new FileExtensionContentTypeProvider().TryGetContentType(path, out var contentType);
        return contentType;
    }

    public string Format { get; set; }

    public static string XSLX_FORMAT = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
}
