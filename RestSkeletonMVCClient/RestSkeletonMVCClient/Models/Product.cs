﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestSkeletonMVCClient.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public string URL { get; set; }
    }
}