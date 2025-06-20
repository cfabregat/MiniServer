// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

static class Program
{
    static void Main(string[] args)
    {
        //prueba de logger
       /* var request = new HttpRequest
        {
            Method = "POST",
            Path = "/api/test?debug=true",
            Body = "nombre=Brenda&rol=dev"
        };
        request.Headers["Content-Length"] = request.Body.Length.ToString();

        Logger.LogRequest(request, "127.0.0.1");
        Logger.Log("Logger funcionando correctamente");
       */

        //inicio del server
        var server = new HttpServer();
        server.Start();
    }
}
