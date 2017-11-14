using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VentasFinal.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EMail { get; set; }

        [StringLength(25, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 5)]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [Display(Name = "N° Documento")]
        public string Document { get; set; }

        [NotMapped]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        //Para relacionar con el maestro de documentos si se coloca int? (relacion opcional) la relacion es de 0 a muchos
        public int DocumentTypeID { get; set; }

        //relacionamiento con la tabla de documentType

        public virtual DocumentType DocumentType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}