// MiniServer 1.1

static class Program
{
    static void Main(string[] args)
    {
        var server = new HttpServer();
        server.Start();
    }
}
