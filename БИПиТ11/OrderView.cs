//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace БИПиТ11
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class OrderView
    {
        public int IdO { get; set; }
        public string Client { get; set; }
        public string Service { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }
        public Nullable<int> Total { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public System.DateTime Date { get; set; }
    }
}
