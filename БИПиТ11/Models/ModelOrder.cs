using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace БИПиТ11.Models
{
    public class ModelOrder
    {
        public int IdO { get; set; }
        public string Client { get; set; }
        public string Service { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }
        public Nullable<int> Total { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public System.DateTime Date { get; set; }

        public ModelOrder(int id, string client, string service, int time, int price, int total, DateTime date)
        {
            IdO = id;
            Client = client;
            Service = service;
            Time = time;
            Price = price;
            Total = total;
            Date = date;
        }
    }
}