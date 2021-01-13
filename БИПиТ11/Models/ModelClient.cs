using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace БИПиТ11.Models
{
    public class ModelClient
    {
        public int IdC { get; set; }
        public string Client1 { get; set; }
        public long Phone { get; set; }

        public ModelClient(int id, string client, long phone)
        {
            IdC = id;
            Client1 = client;
            Phone = phone;
        }
    }
}