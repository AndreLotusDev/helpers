public class MimeHelper : IMimeHelper
{
    public string GetContentType(string path) {
        var found = new FileExtensionContentTypeProvider().TryGetContentType(path, out var contentType);
        return contentType;
    }
}
