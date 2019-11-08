using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestSkeletonClient
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var products = GetProducts("http://localhost:8080/RestSkeleton/products");
             // DataSet data = JsonConvert.DeserializeObject<DataSet>(products);
            Label1.Text = products;

        }

        public string GetProducts(string url)
        {
            var client = new RestClient(url);

            var response = client.Execute(new RestRequest());

            return response.Content;
        }
    }
}