// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

static class Program
{
    static void Main(string[] args)
    {
        var server = new HttpServer();
        server.Start();
    }
}
