using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace БИПиТ11.Models
{
    public class ModelService
    {
        public int IdS { get; set; }
        public string Service1 { get; set; }
        public int Price { get; set; }

        public ModelService(int id, string service, int price)
        {
            IdS = id;
            Service1 = service;
            Price = price;
        }
    }
}