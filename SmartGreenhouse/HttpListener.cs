using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartGreenhouse {
    internal class MyHttpListener {

        private HttpListener listener;
        private readonly string url;

        public MyHttpListener(string url) {
            this.url = url;
            listener = new HttpListener();
            listener.Prefixes.Add(url);
        }

        public void Start() {
            listener.Start();
            Task.Run(() => HandleRequests());
        }

        public void Stop() {
            if (listener.IsListening) {
                listener.Stop();
            }
        }

        private async Task HandleRequests() {
            while (listener.IsListening) {
                try {
                    HttpListenerContext context = await listener.GetContextAsync();
                    HttpListenerRequest request = context.Request;

                    // Only handle POST requests
                    if (request.HttpMethod == "POST") {
                        await HandlePostRequest(request, context.Response);
                    }
                    else {
                        context.Response.StatusCode = 405; // Method Not Allowed
                        context.Response.Close();
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error handling request: {ex.Message}");
                }
            }
        }

        private async Task HandlePostRequest(HttpListenerRequest request, HttpListenerResponse response) {
            try {
                using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding)) {
                    string postData = await reader.ReadToEndAsync();
                    




                   
                    response.StatusCode = 200;
                }
            }
            catch (Exception) {
                response.StatusCode = 500;
            }
            finally {
                response.Close();
            }
        }



    }
}
