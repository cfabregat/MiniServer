using System;
using System.IO;

static class Logger
{
    public static void LogRequest(HttpRequest request, string ip)
    {
        Directory.CreateDirectory("logs");
        string fileName = $"logs/{DateTime.Now:yyyy-MM-dd}.log";
        

        string log = $"{DateTime.Now:HH:mm:ss} | IP: {ip} | {request.Method} {request.Path}";
        if (request.Path.Contains('?'))
        {
            log += $" | Params: {request.Path.Split('?')[1]}";
        }
        if (!string.IsNullOrEmpty(request.Body))
        {
            log += $" | Body: {request.Body}";
        }

        File.AppendAllText(fileName, log + Environment.NewLine);
    }
    public static void Log(string msg)
    {
        Console.WriteLine($"[LOG {DateTime.Now:HH:mm:ss}] {msg}");
    }
}
