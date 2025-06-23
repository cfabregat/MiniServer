using System.Text;

static class HttpResponse
{
    //metodos para construir respuestas HTTP comunes
    public static string Ok(string content)
    {
        return BuildResponse(200, "OK", content);
    }

    public static string NotFound(string content)
    {
        return BuildResponse(404, "Not Found", content);
    }

    public static string BadRequest(string content)
    {
        return BuildResponse(400, "Bad Request", content);
    }


    // Método para construir una respuesta HTTP genérica
    private static string BuildResponse(int statusCode, string statusText, string content)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"HTTP/1.1 {statusCode} {statusText}");
        sb.AppendLine("Content-Type: text/html; charset=utf-8");
        sb.AppendLine($"Content-Length: {Encoding.UTF8.GetByteCount(content)}");
        sb.AppendLine("Connection: close");
        sb.AppendLine();
        sb.Append(content);
        return sb.ToString();
    }
}
