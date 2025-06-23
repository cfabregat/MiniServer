using System;
using System.IO;
using System.Net;
using System.Net.Sockets; //trabajar con sockets TCP.
using System.Text; //leer archivos, manipular texto.
using System.Threading;
using System.IO.Compression;


class HttpServer
{
    private int port;
    private string root = string.Empty; // Inicializar con un valor predete

    //Al crear un HttpServer, carga la configuración desde config.txt.
    public HttpServer()
    {
        LoadConfig();
    }

    public void Start()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"Servidor iniciado en el puerto {port}");


        while (true)
        // Acepta conexiones entrantes y maneja cada cliente en un hilo separado
        {
            TcpClient client = listener.AcceptTcpClient();
            Thread thread = new Thread(() => HandleClient(client));
            thread.Start();
        }
    }

    private void LoadConfig()
    {
        var lines = File.ReadAllLines("config.txt");
        foreach (var line in lines)
        {
            var parts = line.Split('=');
            if (parts.Length != 2) continue;

            if (parts[0] == "PORT") port = int.Parse(parts[1]);
            if (parts[0] == "ROOT") root = parts[1];
        }
    }

    private void HandleClient(TcpClient client)
    {
        try
        {
            using NetworkStream stream = client.GetStream();
            using StreamReader reader = new StreamReader(stream);
            using StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

            var request = HttpRequest.Parse(reader);


            if (request == null)
            {
                writer.Write(HttpResponse.BadRequest("Invalid HTTP request."));
                writer.Flush();
                client.Close();
                return;
            }
            //crea log de la peticion
            Logger.LogRequest(request, ((IPEndPoint)client.Client.RemoteEndPoint!).Address.ToString());


            //servir el archivo index.html si no se especifica
            string path = request.Path == "/" ? "/index.html" : request.Path;
            string filePath = Path.Combine(root, path.TrimStart('/'));

            if (!File.Exists(filePath))
            {
                filePath = Path.Combine(root, "404.html");
                writer.Write(HttpResponse.NotFound(File.ReadAllText(filePath)));
                writer.Flush();
                client.Close();
                return;
            }

            byte[] fileBytes = File.ReadAllBytes(filePath);
            string extension = Path.GetExtension(filePath).ToLower();
            string contentType = extension switch
            {
                ".html" => "text/html",
                ".css" => "text/css",
                ".js" => "application/javascript",
                ".png" => "image/png",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                ".svg" => "image/svg+xml",
                _ => "application/octet-stream"
            };

            // Comprimir solo texto, no imágenes
            byte[] responseBody;
            string encodingHeader = "";
            if (contentType.StartsWith("text"))
            {
                responseBody = CompressWithGzip(Encoding.UTF8.GetString(fileBytes));
                encodingHeader = "Content-Encoding: gzip\r\n";
            }
            else
            {
                responseBody = fileBytes;
            }

            string headers = $"HTTP/1.1 200 OK\r\n" +
                             $"{encodingHeader}" +
                             $"Content-Type: {contentType}\r\n" +
                             $"Content-Length: {responseBody.Length}\r\n\r\n";

            byte[] headerBytes = Encoding.UTF8.GetBytes(headers);
            stream.Write(headerBytes, 0, headerBytes.Length);
            stream.Write(responseBody, 0, responseBody.Length);

            stream.Flush();


        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al manejar cliente: " + ex.Message);
        }

    }
    static byte[] CompressWithGzip(string content)
    {
        var bytes = Encoding.UTF8.GetBytes(content);
        using var outputStream = new MemoryStream();
        using (var gzip = new GZipStream(outputStream, CompressionMode.Compress))
        {
            gzip.Write(bytes, 0, bytes.Length);
        }
        return outputStream.ToArray();
    }

}