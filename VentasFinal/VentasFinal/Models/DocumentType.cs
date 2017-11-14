using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentasFinal.Models
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }

        [Display(Name = "Tipo de Documento")]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string Document { get; set; }

        //relacion con la tabla empleados
        public virtual ICollection<Employee> Employees { get; set; }
        //relación con la tabla Customers
        public virtual ICollection<Customer> Customers { get; set; }
    }
}