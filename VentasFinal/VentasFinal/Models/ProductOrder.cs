using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentasFinal.Models
{
    public class ProductOrder : Product
    {

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        public float Quantity { get; set; }

        //propiedad de solo lectura Value
        public decimal Value { get { return Price * (decimal)Quantity;  } }

    }
}