using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VentasFinal.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        //Cambiar el nombre de la Table en la Base de Datos

        //[Column("Nombres")]
        //------------
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [StringLength(50, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Salario")]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        //FORMATO A LOS DATOS DisplayFormat
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Salary { get; set; }

        [Display(Name = "Porcentaje")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float BonusPercent { get; set; }

        [Display(Name = "Fecha de Cumpleaños")]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        //Solo pone la fecha no la hora
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Hora de Inicio")]
        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        //Solo pone la hora no la fecha
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Página de Referencia")]
        [DataType(DataType.Url)]
        public string URL { get; set; }

        //Cambiar nombre de la llave foránea no recomendado
        //[ForeignKey("xxxxxx")]

        [Required(ErrorMessage = "Usted debe de Ingresar un {0}")]
        [Display(Name = "Tipo de Documento")]
        public int DocumentTypeID { get; set; }

        //Campo calculado que no se encuentra en la Base de datos

        [NotMapped]
        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }

        [NotMapped]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        //Relaciona de con el model de DocumentType
        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}