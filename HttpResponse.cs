using System;
using System.IO;
using System.IO.Compression;
using System.Text;

static class HttpResponse
{
    public static string Ok(string content, bool enableCompression = true)
    {
        return BuildResponse(200, "OK", content, enableCompression);
    }

    public static string NotFound(string content, bool enableCompression = true)
    {
        return BuildResponse(404, "Not Found", content, enableCompression);
    }

    private static string BuildResponse(int statusCode, string statusText, string content, bool enableCompression)
    {
        var sb = new StringBuilder();
        byte[] contentBytes = Encoding.UTF8.GetBytes(content);
        bool isCompressed = false;
        string contentEncoding = string.Empty;

        if (enableCompression)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    gzipStream.Write(contentBytes, 0, contentBytes.Length);
                }
                contentBytes = memoryStream.ToArray();
                isCompressed = true;
                contentEncoding = "Content-Encoding: gzip\r\n";
            }
        }

        sb.AppendLine($"HTTP/1.1 {statusCode} {statusText}");
        sb.AppendLine("Content-Type: text/html; charset=utf-8");
        sb.AppendLine(contentEncoding);
        sb.AppendLine($"Content-Length: {contentBytes.Length}");
        sb.AppendLine("Connection: close");
        sb.AppendLine();

        if (isCompressed)
        {
            sb.Append(Convert.ToBase64String(contentBytes));
        }
        else
        {
            sb.Append(content);
        }

        return sb.ToString();
    }
}