using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Entities.Models
{
    public class alumnocls
    {
        [Display(Name = "LEGAJO")]
        public int id_alumno { get; set; }
        [Display(Name = "NOMBRE")]
        public string nombre { get; set; }
        [Display(Name = "APELLIDO")]
        public string apellido { get; set; }
        [Display(Name = "EDAD")]
        public Nullable<int> edad { get; set; }
        [Display(Name = "MAIL")]
        public string mail { get; set; }
        [Display(Name = "TELEFONO")]
        public string telefono { get; set; }
        [Display(Name = "DOMICILIO")]
        public string domicilio { get; set; }
        [Display(Name = "CIUDAD")]
        public Nullable<int> id_ciudad { get; set; }
    }
}