using System;
using System.Net;

class HttpServer
{
    static void Main(string[] args)
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/"); //ddfine o endereço e a porta do servidor

        listener.Start(); //inicia o servidor

        Console.WriteLine("Servidor HTTP iniciado...");

        while (true)
        {
            HttpListenerContext context = listener.GetContext(); //aguarda uma solicitação

            // Processa a solicitação e envia uma resposta
            HttpListenerResponse response = context.Response;
            string responseString = "Essa resposta esta sendo enviada do servidor para o cliente.";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}
