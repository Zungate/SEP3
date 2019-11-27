using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSkeletonTester
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public string URL { get; set; }

        public Product(int id, string title, string size, string uRL)
        {
            Id = id;
            Title = title;
            Size = size;
            URL = uRL;
        }

        public Product() { }
    }
}