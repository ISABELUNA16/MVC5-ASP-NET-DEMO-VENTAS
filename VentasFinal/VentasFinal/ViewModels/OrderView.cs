using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentasFinal.Models;

namespace VentasFinal.ViewModels
{
    public class OrderView
    {
        public Customer Customer { get; set; }
        public ProductOrder ProductOrder { get; set; }
        public List<ProductOrder> Products { get; set; }
        public Employee Employee { get; set; }
    }
}