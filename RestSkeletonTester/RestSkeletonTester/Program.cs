using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSkeletonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            var json = program.GetJSON("http://localhost:8080/RestSkeleton/products/get10");
                       
            var client = new RestClient("http://localhost:8080/RestSkeleton/products/");
            var request = new RestRequest("buy", Method.POST);

            Console.WriteLine("Adding headers");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.Parameters.Clear();
            Console.WriteLine("Adding params");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            var response = client.Execute(request);

            Console.WriteLine("Reponse " + response.Content);
            Console.ReadKey();
        }

        public string GetJSON(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute(new RestRequest());

            return response.Content;
        }
        // POST: Product/Buy

    }
}
