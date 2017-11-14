using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentasFinal.Models
{
    public class Order
    {
        [Key]

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }

        public virtual Customer Customer { get; set; }        
        
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Employee Employee { get; set; }

    }
}